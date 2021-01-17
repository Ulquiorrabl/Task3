using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Ports;
using Task3.ATS.Regions;
using Task3.ATS.Reports;
using Task3.Statuses;

namespace Task3.ATS
{
    class Stantion
    {
        private List<IPort> ports;

        public int NumOfPorts { get { return ports.Count; } }
        public StationStatus Status { get; private set; }
        public Stantion()
        {
            ports = new List<IPort>();
            Status = StationStatus.Online;
        }

        public IPort GeneratePort(Region region, string number)
        {
            Port port = new Port(region, number);
            ports.Add(port);
            port.Call += ConnectPorts;
            return port;
        }

        public Report GetPortById(int id)
        {
            try
            {
                return new Report(StationStatus.Online, ports[id], "Success");
            }
            catch(Exception e)
            {
                return new Report(StationStatus.Error, null, e.Message);
            }
        }

        public Report GetPortByNumber(string number)
        {
            try
            {
                foreach (IPort port in ports)
                {
                    if(port.Number == number)
                    {
                        return new Report(StationStatus.Online, port);
                    }                  
                }
                return new Report(StationStatus.Error, null, "NotFound");
            }
            catch (Exception e)
            {
                return new Report(StationStatus.Error, null, e.Message);
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
            int firsPortId = IndexOfPort(number);
            ports[firsPortId].ConnectedToPort(sender.ToString());
        }

    }
}
