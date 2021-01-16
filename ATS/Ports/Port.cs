using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Regions;

namespace Task3.ATS.Ports
{
    class Port : IPort
    {
        public Region Region { get; private set; }     
        public string Number { get; private set; }
        public Port(Region region, string number)
        {
            this.Region = region;
            this.Number = number;
        }
    }
}
