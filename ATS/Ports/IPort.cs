using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.ATS.Regions;

namespace Task3.ATS.Ports
{
    interface IPort
    {
        string Number { get; }
        Region Region { get; }
    }
}
