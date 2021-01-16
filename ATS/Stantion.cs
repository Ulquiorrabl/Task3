using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Ports;
using Task3.ATS.Regions;

namespace Task3.ATS
{
    class Stantion
    {
        private List<IPort> ports;

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
            return port;
        }

    }
}
