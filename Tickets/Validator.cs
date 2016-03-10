using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
    public static class Validator
    {
        public static bool IsPresent(TextBox tbox)
        {
            if (tbox.Text == "")
            {
                MessageBox.Show(tbox.Tag + " cannot be empty.  Please enter a value.","Required Field");
                tbox.Focus();
                return false;
            }
            else return true;
        }

        public static bool IsInteger(TextBox tbox) 
        {
            string toParse = tbox.Text;
            int whatevs;
            if (!(Int32.TryParse(toParse, out whatevs)) || whatevs < 1)
            {
                MessageBox.Show(tbox.Tag + " requires a positive integer greater than zero.", "Invalid Value");
                tbox.Focus();
                return false;
            }
            else return true;
        }

        // and a method to check that it's a valid time
        public static bool IsTime(TextBox tbox)
        {
            DateTime whatevs;
            if (!(DateTime.TryParse(tbox.Text,out whatevs)))
            {
                MessageBox.Show(tbox.Tag + " does not appear to be a valid time.  Please check your entry.",
                    "Invalid time");
                return false;
            }
            else return true;
        }

        // checks that the start and end time allow for at least two time slots
        public static bool AtLeastTwoSlots(TextBox start, TextBox end, TextBox minutes)
        {
            DateTime anfang, endung;
            if (!(DateTime.TryParse(start.Text, out anfang)))
            {
                MessageBox.Show(start.Tag + " does not appear to be a valid time.  Please check your entry.",
                    "Invalid time");
                return false;
            }
            if (!(DateTime.TryParse(end.Text, out endung)))
            {
                MessageBox.Show(end.Tag + " does not appear to be a valid time.  Please check your entry.",
                    "Invalid time");
                return false;
            }
            int minuten = Convert.ToInt32(minutes.Text);

            // we need to verify that the opening hours are at least the same length as the number of minutes.
            // this ensures one slot at opening and one slot at closing.
            TimeSpan timeDiff = endung - anfang;
            // need to convert timespan to a total number of minutes:
            int totalMinutes = (timeDiff.Hours * 60) + timeDiff.Minutes;
            // MessageBox.Show(totalMinutes.ToString());
            if (totalMinutes < minuten)
            {
                // TODO add alert message
                string msg = "Your hours of operation do not allow for at least two batches of tickets.\n" +
                    "Please either reduce the number of minutes per window, or extend your hours of operation.";
                string caption = "Not enough ticket batches.";
                MessageBox.Show(msg, caption);
                return false;
            }
            else return true;
        }
    }
}
