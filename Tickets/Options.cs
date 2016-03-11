using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class Options
    {
        // this is a helper object to store application options

        public int MinutesPerWindow;
        public int GuestsPerWindow;
        public DateTime StartTime;
        public DateTime EndTime;
        public int FirstTicket; // first ticket number to use

        // a generic constructor
        public Options() { }

        // and one that takes values
        public Options(int minuten, int gaeste, DateTime anfang, DateTime ende, int erste)
        {
            this.MinutesPerWindow = minuten;
            this.GuestsPerWindow = gaeste;
            this.StartTime = anfang;
            this.EndTime = ende;
            this.FirstTicket = erste;
        }
    }
}
