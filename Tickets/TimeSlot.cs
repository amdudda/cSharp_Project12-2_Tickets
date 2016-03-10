using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class TimeSlot
    {
        // public attributes
        public DateTime StartTime;
        public int Duration;  // length of time slot in minutes
        public int TicketsPerSlot;

        // generic constructor
        public TimeSlot() { }

        // and one that takes values - vars are french to keep them distinct
        public TimeSlot(DateTime start, int duree, int billets)
        {
            this.StartTime = start;
            this.Duration = duree;
            this.TicketsPerSlot = billets;
        }

        public DateTime GetEndTime()
        {
            // returns the end of the time slot; this is really the start of the next slot.
            return this.StartTime.AddMinutes(this.Duration);
        }
    }
}
