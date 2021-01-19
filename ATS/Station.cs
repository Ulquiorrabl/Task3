using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Ports;
using Task3.ATS.Regions;
using Task3.ATS.ATSReports;
using Task3.Statuses;

namespace Task3.ATS
{
    class Station
    {
        private List<IPort> ports;

        public StationStatus Status { get; private set; }
        public Station()
        {
            ports = new List<IPort>();
            Status = StationStatus.Online;
        }

        public IPort GeneratePort(Region region, string number)
        {
            Port port = new Port(region, number);
            ports.Add(port);
            port.Call += ConnectPorts;
            port.CallEnded += DisconnectPorts;
            return port;
        }

        public ATSReport GetPortById(int id)
        {
            try
            {
                return new ATSReport(StationStatus.Online, ports[id], "Success");
            }
            catch(Exception e)
            {
                return new ATSReport(StationStatus.Error, null, e.Message);
            }
        }

        public ATSReport GetPortByNumber(string number)
        {
            try
            {
                foreach (IPort port in ports)
                {
                    if(port.Number == number)
                    {
                        return new ATSReport(StationStatus.Online, port);
                    }                  
                }
                return new ATSReport(StationStatus.Error, null, "NotFound");
            }
            catch (Exception e)
            {
                return new ATSReport(StationStatus.Error, null, e.Message);
            }
        }

        public int IndexOfPort(string number)
        {
            for (int i=0; i<ports.Count; i++)
            {
                if(ports[i].Number == number)
                {
                    return i;
                }
            }
            return -1;
        }

        void ConnectPorts(object sender, string number)
        {
            IPort firstPort = ports[IndexOfPort(sender.ToString())];
            int secondPortId = IndexOfPort(number);
            if (secondPortId != -1)
            {
                IPort secondPort = ports[secondPortId];
                if(firstPort.Region == secondPort.Region)
                {
                    secondPort.ConnectedToPort(firstPort.Number);
                }
                else
                {
                    firstPort.EndCall();
                }
            }
        }

        void DisconnectPorts(object sender, string number)
        {
            int secondPortId = IndexOfPort(number);
            if(secondPortId != -1)
            {
                ports[secondPortId].EndCall();
            }
        }

    }
}
