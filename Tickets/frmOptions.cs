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
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void IntegerTextbox_Leave(object sender, EventArgs e)
        {
            // don't let the user leave if the data is invalid
            TextBox t = (TextBox) sender;
            if (!(Validator.IsPresent(t) && Validator.IsInteger(t))) t.Focus();
        }

        private void TimeTextbox_Leave(object sender, EventArgs e)
        {
            // don't let the user leave if the data is invalid
            TextBox t = (TextBox)sender;
            if (!(Validator.IsPresent(t) && Validator.IsTime(t))) t.Focus();
        }

        // need a method to reset program options
        private void ResetOptions()
        {
            throw new NotImplementedException();
        }

        // this initializes settings and starts up the ticket queue
        private void btnOK_Click(object sender, EventArgs e)
        {
            // first, make sure our input is valid and that there is enough time for at least two time slots.
            // textbox data should be valid if our validation works, but let's doublecheck to be sure
            bool validTextboxData = (Validator.IsPresent(txtMinutes) && Validator.IsInteger(txtMinutes) &&
                Validator.IsPresent(txtGuests) && Validator.IsInteger(txtGuests) &&
                Validator.IsPresent(txtFirstTicket) && Validator.IsInteger(txtFirstTicket) &&
                Validator.IsPresent(txtStartTime) && Validator.IsTime(txtStartTime) &&
                Validator.IsPresent(txtEndTime) && Validator.IsTime(txtEndTime));
            // and see if we have at least two time slots
            bool validInterval = Validator.AtLeastTwoSlots(txtStartTime, txtEndTime, txtMinutes);

            // if we really do have valid data, proceed.
            if (validTextboxData && validInterval)
            {
                MessageBox.Show("Success!!");
                // TODO generate slots & tickets and move to ticket management window.  
            }
        }
    }
}
