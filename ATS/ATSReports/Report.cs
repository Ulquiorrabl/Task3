using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Statuses;
using Task3.ATS.Ports;

namespace Task3.ATS.ATSReports
{
    class ATSReport
    {
        public string Message;
        StationStatus Status;
        IPort Port;

        public ATSReport(StationStatus status,  IPort port = null, string message = null)
        {
            this.Message = message;
            this.Status = status;
            this.Port = port;
        }
    }
}
