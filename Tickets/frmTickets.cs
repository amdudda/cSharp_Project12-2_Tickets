using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tickets
{
    public partial class frmTickets : Form
    {
        // need an array of time slots and an array of tickets
        List<TimeSlot> availableSlots = new List<TimeSlot>();
        List<Ticket> ticketQueue = new List<Ticket>();
        TimeSlot currentSlot;
        public Options options;
        public Timer timer = new Timer();

        public frmTickets()
        {
            InitializeComponent();
        }

        private void frmTickets_Load(object sender, EventArgs e)
        {
            // eventually this will move elsewhere
            DateTime currentTime = DateTime.Now;
            this.Text = currentTime.ToShortTimeString() + "(Open)";
            // let's load up timeslot data with defaults for now.
            options = new Options(5, 5, currentTime, currentTime.AddHours(4), 1);
            // have the user give us data.
            frmOptions initOptions = new frmOptions();
            options = initOptions.ResetOptions(options);
            generateTimeSlots();
            // and now we kick off the timer
            timer.Interval = 1000;
            timer.Tick += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, EventArgs e)
        {
            // update title bar and queue summary
            updateTitleBar();
            UpdateQueueSummary();
        }

        private void updateTitleBar()
        {
            DateTime curTime = DateTime.Now;
            string title = curTime.ToShortTimeString();
            if (curTime <= options.EndTime) title += " (Open)";
            else title += " (Closed)";
            this.Text = title;
        }

        private void generateTimeSlots()
        {
            // generates array of available time slots
            int mins = options.MinutesPerWindow;
            int guests = options.GuestsPerWindow;
            DateTime start = options.StartTime;
            DateTime end = options.EndTime;
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
            int firstTicket = options.FirstTicket;
            // inspects timeslot array and generates a ticket for the next available slot.
            Ticket t = new Ticket();
            // if the array is empty, generate the first ticket
            if (ticketQueue == null || ticketQueue.Count() == 0)
            {
                t.TicketNum = firstTicket;
                t.AdmitTime = GetNextTimeSlot();
                return t;
            }
            else     
            {
                // there are already tickets in the queue, generate and return a new ticket
                // I coded this and then extracted a method with {ctrl+r,m}
                return GenerateNewTicket(t);
   
            } // end if-else to create ticket

        } // end GetNextTicket

        private Ticket GenerateNewTicket(Ticket t)
        {
            Ticket lastTicket = ticketQueue.Last<Ticket>();
            int nextTicketNum = lastTicket.GetNextTicketNumber();

            // check that we still have time slots available before issuing the next ticket
            if (GetNextTimeSlot() == null)
            {
                // we have no more tickets available - inform the user
                string msg = "The last available ticket has been issued.  No more tickets available today!";
                string caption = "Out of Tickets!";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
            else
            {
                // create our new ticket and return it
                t.TicketNum = nextTicketNum;
                t.AdmitTime = GetNextTimeSlot();
                return t;
            } // end if-else to add ticket to the queue
        } // end GenerateNewTicket

        private void btnIssueTicket_Click(object sender, EventArgs e)
        {
            // first, fetch the next available ticket - null is returned if no more slots available
            Ticket ticket = GetNextTicket();
            if (ticket != null)
            {
                // add it to ticketQueue
                ticketQueue.Add(ticket);
                // and also add it to the listbox
                lstTicketQueue.Items.Add(ticket.ToString());
                // and update the queue summary
                UpdateQueueSummary();
            }
        } // end btnIssueTicket

        private void UpdateQueueSummary()
        {
            // and update queue info
            lblTicketsOutstanding.Text = "Total tickets outstanding:  \t" + ticketQueue.Count.ToString();
            // get next available time slot
            TimeSlot nextSlot = GetNextTimeSlot();
            // the above is true for most tickets, but what if it's the last ticket in its batch?
            if (nextSlot != null)
            {
                // one is available, change to reflect this
                // update next slot display
                lblNextEntry.Text = "Next available entry:  \t" + nextSlot.StartTime.ToShortTimeString();
            }
            else
            {
                // none available, note this
                lblNextEntry.Text = "No more tickets available.";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // TODO: warn user data will be cleared.
            // get updated options 
            frmOptions resetOptions = new frmOptions();
            options = resetOptions.ResetOptions(options);

            // and clear the form and both Lists
            lstTicketQueue.Items.Clear();
            availableSlots.Clear();
            ticketQueue.Clear();

            // and generate a new set of available time slots
            generateTimeSlots();
        }

        // this returns the next available time slot
        private TimeSlot GetNextTimeSlot()
        {
            TimeSlot nextSlot = null;
            // First, find a time that hasn't happened yet
            DateTime currentTime = DateTime.Now;
            foreach (TimeSlot ts in availableSlots)
            {
                if (currentTime < ts.StartTime)
                {
                    // we've found the next slot - break out of the loop
                    nextSlot = ts;
                    break;
                }
            }
            // TODO: but what if all tickets are already assigned for that slot?  check the next slot!
            bool keinZeit = true;
            while (keinZeit) {
            int ticketCount = 0;
                foreach (Ticket t in ticketQueue)
                {
                    // count how many tickets are assigned to the current slot
                    if (t.AdmitTime == nextSlot) ticketCount++;
                }
                if (ticketCount < options.GuestsPerWindow)
                {
                    // we found our slot, break the while loop
                    keinZeit = false;
                }
                else
                {
                    // move to the next available slot in the array and try again
                    int nextIndex = availableSlots.IndexOf(nextSlot) + 1;
                    if (nextIndex < availableSlots.Count)
                    {
                        nextSlot = availableSlots[nextIndex];
                    }
                    else nextSlot = null;
                }
            }

            return nextSlot;
        }

    } // end partial class frmTickets
}
