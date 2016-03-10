using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Ticket
    {
        public int TicketNum;
        public TimeSlot AdmitTime;

        // generic constructor
        public Ticket() { }

        // this constructor takes attributes - german this time, again for easy disambiguation
        public Ticket(int nummer, TimeSlot zeit)
        {
            this.TicketNum = nummer;
            this.AdmitTime = zeit;
        }

        public int GetNextTicketNumber()
        {
            return this.TicketNum + 1;
        }

        public string GetTicketInfo()
        {
            return "Ticket " + this.TicketNum + ": " + this.AdmitTime.StartTime.ToShortTimeString();
        }
    }
}
