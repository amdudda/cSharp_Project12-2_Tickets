namespace Tickets
{
    partial class frmTickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNowAdmitting = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIssueTicket = new System.Windows.Forms.Button();
            this.lblNextEntry = new System.Windows.Forms.Label();
            this.lblTicketsOutstanding = new System.Windows.Forms.Label();
            this.lstTicketQueue = new System.Windows.Forms.ListBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A.M. Dudda - Project 12.2 - Tickets";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNowAdmitting);
            this.groupBox1.Location = new System.Drawing.Point(13, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guests with the following tickets may now enter:";
            // 
            // lblNowAdmitting
            // 
            this.lblNowAdmitting.AutoSize = true;
            this.lblNowAdmitting.Location = new System.Drawing.Point(7, 20);
            this.lblNowAdmitting.Name = "lblNowAdmitting";
            this.lblNowAdmitting.Size = new System.Drawing.Size(22, 13);
            this.lblNowAdmitting.TabIndex = 0;
            this.lblNowAdmitting.Text = "1-5";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIssueTicket);
            this.groupBox2.Controls.Add(this.lblNextEntry);
            this.groupBox2.Controls.Add(this.lblTicketsOutstanding);
            this.groupBox2.Location = new System.Drawing.Point(13, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 94);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ticket Availability";
            // 
            // btnIssueTicket
            // 
            this.btnIssueTicket.Location = new System.Drawing.Point(13, 65);
            this.btnIssueTicket.Name = "btnIssueTicket";
            this.btnIssueTicket.Size = new System.Drawing.Size(99, 23);
            this.btnIssueTicket.TabIndex = 2;
            this.btnIssueTicket.Text = "&IssueTicket";
            this.btnIssueTicket.UseVisualStyleBackColor = true;
            this.btnIssueTicket.Click += new System.EventHandler(this.btnIssueTicket_Click);
            // 
            // lblNextEntry
            // 
            this.lblNextEntry.AutoSize = true;
            this.lblNextEntry.Location = new System.Drawing.Point(10, 45);
            this.lblNextEntry.Name = "lblNextEntry";
            this.lblNextEntry.Size = new System.Drawing.Size(143, 13);
            this.lblNextEntry.TabIndex = 1;
            this.lblNextEntry.Text = "Next available entry:      Now";
            // 
            // lblTicketsOutstanding
            // 
            this.lblTicketsOutstanding.AutoSize = true;
            this.lblTicketsOutstanding.Location = new System.Drawing.Point(10, 20);
            this.lblTicketsOutstanding.Name = "lblTicketsOutstanding";
            this.lblTicketsOutstanding.Size = new System.Drawing.Size(113, 13);
            this.lblTicketsOutstanding.TabIndex = 0;
            this.lblTicketsOutstanding.Text = "No tickets outstanding";
            // 
            // lstTicketQueue
            // 
            this.lstTicketQueue.FormattingEnabled = true;
            this.lstTicketQueue.Location = new System.Drawing.Point(13, 187);
            this.lstTicketQueue.Name = "lstTicketQueue";
            this.lstTicketQueue.Size = new System.Drawing.Size(259, 147);
            this.lstTicketQueue.TabIndex = 3;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(13, 350);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.Text = "&Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(196, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 391);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.lstTicketQueue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmTickets";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTickets_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNowAdmitting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIssueTicket;
        private System.Windows.Forms.Label lblNextEntry;
        private System.Windows.Forms.Label lblTicketsOutstanding;
        private System.Windows.Forms.ListBox lstTicketQueue;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnExit;
    }
}

