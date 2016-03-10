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
        List<TimeSlot> availableSlots = new List<TimeSlot>();
        List<Ticket> ticketQueue = new List<Ticket>(); 

        public frmTickets()
        {
            InitializeComponent();
        }

        private void frmTickets_Load(object sender, EventArgs e)
        {
            // eventually this will move elsewhere
            DateTime currentTime = DateTime.Now;
            this.Text = currentTime.ToShortTimeString() + "(Open)";
            // let's load up timeslot data with deafaults for now.
            generateTimeSlots();
        }

        private void generateTimeSlots()
        {
            // generates array of available time slots - should this take an array?
            // let's hard-code this with our defaults for now
            int mins = 120;
            int guests = 5;
            DateTime start = Convert.ToDateTime("10:49 AM");
            DateTime end = Convert.ToDateTime("2:49 PM");
            //int firstTicket = 1;

            DateTime nextTime = start;
            do  // create our time slots
            {
                TimeSlot ts = new TimeSlot(nextTime, mins, guests);
                availableSlots.Add(ts);
                nextTime = nextTime.AddMinutes(mins);
                //MessageBox.Show("added a time slot!");
            } while (nextTime <= end);

        } // end generateTimeSlots

        private Ticket GetNextTicket()
        {
            int firstTicket = 1;
            // inspects timeslot array and generates a ticket for the next available slot.
            Ticket t = new Ticket();
            // if the array is empty, generate the first ticket
            if (ticketQueue == null || ticketQueue.Count() == 0)
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

                // maximum number of tickets that can be assigned
                int maxNumberOfTickets = availableSlots[0].TicketsPerSlot * availableSlots.Count;
                TimeSlot myTimeSlot;
                if (countOfTickets == maxNumberOfTickets)
                {
                    // we have no more tickets available
                    string msg = "The last available ticket has been issued.  No more tickets available today!";
                    string caption = "Out of Tickets!";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return null;
                }
                else if (countOfTickets % ticketsPerSlot == 0)
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

        private void btnIssueTicket_Click(object sender, EventArgs e)
        {
            // first, fetch the next available ticket - null is returned if no more slots available
            Ticket ticket = GetNextTicket();
            if (ticket != null)
            {
                // add it to ticketQueue
                ticketQueue.Add(ticket);
                // and also add it to the listbox
                lstTicketQueue.Items.Add(ticket.GetTicketInfo());
            }
        } // end btnIssueTicket

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

    } // end partial class frmTickets
}
