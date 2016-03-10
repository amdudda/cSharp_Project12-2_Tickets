using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
    public class Validator
    {
        public bool IsPresent(TextBox tbox)
        {
            if (tbox.Text == "")
            {
                MessageBox.Show(tbox.Tag + " cannot be empty.  Please enter a value.","Required Field");
                tbox.Focus();
                return false;
            }
            else return true;
        }

        public bool IsInteger(TextBox tbox) 
        {
            string toParse = tbox.Text;
            short whatevs;
            if (!(Int16.TryParse(toParse, out whatevs)) || whatevs < 1)
            {
                MessageBox.Show(tbox.Tag + " requires a positive integer greater than zero.", "Invalid Value");
                tbox.Focus();
                return false;
            }
            else return true;
        }

        // and a method to check that it's a valid time
        public bool IsTime(TextBox tbox)
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
        // should really take three textboxes??
        public bool AtLeastTwoSlots(DateTime anfang, DateTime endung, int minuten)
        {
            // we need to verify that the opening hours are at least the same length as the number of minutes.
            // this ensures one slot at opening and one slot at closing.
            TimeSpan timeDiff = endung - anfang;
            if (timeDiff.Minutes >= minuten)
            {
                // TODO add alert message
                return false;
            }
            else return true;
        }
    }
}
