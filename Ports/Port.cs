using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Regions;

namespace Task3.Ports
{
    class Port
    {
        Region region;
        public Port(Region region)
        {
            this.region = region;
        }
    }
}
