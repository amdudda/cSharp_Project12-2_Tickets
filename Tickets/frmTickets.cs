using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
    public partial class frmTickets : Form
    {
        // need an array of time slots and an array of tickets
        List<TimeSlot> availableSlots;
        List<Ticket> ticketQueue; 

        public frmTickets()
        {
            InitializeComponent();
        }

        private void frmTickets_Load(object sender, EventArgs e)
        {
            // eventually this will move elsewhere
            DateTime currentTime = DateTime.Now;
            this.Text = currentTime.ToShortTimeString() + "(Open)";
        }

        private void generateTimeSlots()
        {
            // generates array of available time slots - should this take an array?
            // let's hard-code this with our defaults for now
            int mins = 5;
            int guests = 5;
            DateTime start = Convert.ToDateTime("10:49 AM");
            DateTime end = Convert.ToDateTime("2:49 PM");
            int firstTicket = 1;

            DateTime nextTime = start;
            do  // create our time slots
            {
                TimeSlot ts = new TimeSlot(nextTime, mins, guests);
                availableSlots.Add(ts);
                nextTime.AddMinutes(mins);
            } while (nextTime <= end);
        }

        private Ticket GetNextTicket()
        {
            int firstTicket = 1;
            // inspects timeslot array and generates a ticket for the next available slot.
            Ticket t = new Ticket();
            // if the array is empty, generate the first ticket
            if (ticketQueue.Count() == 0)
            {
                t.TicketNum = firstTicket;
                t.AdmitTime = availableSlots[0];
            }
            else  // there are already tickets in the queue, fetch the last ticket and get the next ticket number               
            {
                 Ticket lastTicket = ticketQueue.Last<Ticket>();
                int nextTicketNum = lastTicket.GetNextTicketNumber();
                // now to figure out what the next available time slot is - a couple of different ways to do this.  let's modulo the tickets per slot; if it's zero, get the next time slot, otherwise use the current one.
                int countOfTickets = ticketQueue.Count();
                int ticketsPerSlot = lastTicket.AdmitTime.TicketsPerSlot;  
                // ^^^ technically a static value, but I have to store it this way to meet assignment spec
                TimeSlot myTimeSlot;
                if (countOfTickets % ticketsPerSlot == 0)
                {
                    // we need a new time slot
                    // find the index of the previous ticket's time slot in the timeslot array
                    int index = availableSlots.IndexOf(lastTicket.AdmitTime);
                    // then assign the next slot's info for the new ticket
                    myTimeSlot = availableSlots[index + 1];
                }
                else
                {
                    // use the same time slot as the preceding ticket
                    myTimeSlot = lastTicket.AdmitTime;
                } // end if-else to add ticket to the queue

                // and now create our new ticket
                t.TicketNum = nextTicketNum;
                t.AdmitTime = myTimeSlot;
                                
            } // end if-else to create ticket

            // and return our new ticket
            return t;

        } // end GetNextTicket

    } // end partial class frmTickets
}
