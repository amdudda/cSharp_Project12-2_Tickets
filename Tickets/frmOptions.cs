﻿using System;
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
        private Options myOptions = new Options();

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
        public Options ResetOptions(Options oldOptions)
        {
            // debugging:  MessageBox.Show(oldOptions.StartTime.ToShortTimeString());
            //take old options and populate our screen with them
            txtMinutes.Text = oldOptions.MinutesPerWindow.ToString();
            txtGuests.Text = oldOptions.GuestsPerWindow.ToString();
            txtStartTime.Text = oldOptions.StartTime.ToShortTimeString();
            txtEndTime.Text = oldOptions.EndTime.ToShortTimeString();
            txtFirstTicket.Text = oldOptions.FirstTicket.ToString();
            
            this.ShowDialog();
            // and return updated options
            return myOptions;
        }

        // this initializes settings and starts up the ticket queue
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
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
                    //MessageBox.Show("Success!!");
                    // generate new options & return to ticket management window.
                    // gather values
                    int neueMinuten = Convert.ToInt32(txtMinutes.Text);
                    int neueGaeste = Convert.ToInt32(txtGuests.Text);
                    DateTime neuesAnfang = Convert.ToDateTime(txtStartTime.Text);
                    DateTime neuesEnde = Convert.ToDateTime(txtEndTime.Text);
                    // there is an edge case after 8pm, where the default "12:xx am" is parsed as "earlier the same day" instead of "the next morning".
                    if (neuesAnfang.Hour >= 20 && neuesEnde.Hour <= 4)
                    {
                        neuesEnde = neuesEnde.AddDays(1);
                    }
                    int neuesTicket = Convert.ToInt32(txtFirstTicket.Text);

                    // update myOptions object
                    myOptions = new Options(neueMinuten, neueGaeste, neuesAnfang, neuesEnde, neuesTicket);

                    // and close the window
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // validation should prevent errors, but let's be sure the program breaks reasonably gracefully
                // show helpful error message instead of stacktrace
                string msg = ex.Message +
                    "\nPlease contact your IT staff for help in troubleshooting the problem.";
                // + "\n======\n" + ex.StackTrace;
                string caption = ex.GetType().ToString();
                MessageBox.Show(msg, caption);
                // and return back to our screen in case it's a data problem the user can manage to spot and fix
                return;
            }
        }
    }
}
