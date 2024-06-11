namespace Obsługa_Apteki
{
    partial class Support
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Support));
            this.lblSupport = new System.Windows.Forms.Label();
            this.lblPhoneNumber1 = new System.Windows.Forms.Label();
            this.groupBoxPhone = new System.Windows.Forms.GroupBox();
            this.lblPhoneNumber2 = new System.Windows.Forms.Label();
            this.lblPhoneTip = new System.Windows.Forms.Label();
            this.lblContactDays = new System.Windows.Forms.Label();
            this.groupBoxMail = new System.Windows.Forms.GroupBox();
            this.lblMailDays = new System.Windows.Forms.Label();
            this.lblMailTip = new System.Windows.Forms.Label();
            this.lblMail1 = new System.Windows.Forms.Label();
            this.groupBoxPhone.SuspendLayout();
            this.groupBoxMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSupport
            // 
            this.lblSupport.AutoSize = true;
            this.lblSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSupport.Location = new System.Drawing.Point(284, 0);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(230, 50);
            this.lblSupport.TabIndex = 0;
            this.lblSupport.Text = "Potrzebujesz pomocy?\r\nSkontaktuj się z nami";
            // 
            // lblPhoneNumber1
            // 
            this.lblPhoneNumber1.AutoSize = true;
            this.lblPhoneNumber1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPhoneNumber1.Location = new System.Drawing.Point(6, 36);
            this.lblPhoneNumber1.Name = "lblPhoneNumber1";
            this.lblPhoneNumber1.Size = new System.Drawing.Size(129, 20);
            this.lblPhoneNumber1.TabIndex = 1;
            this.lblPhoneNumber1.Text = "+48 731 015 231";
            // 
            // groupBoxPhone
            // 
            this.groupBoxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxPhone.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxPhone.Controls.Add(this.lblPhoneNumber2);
            this.groupBoxPhone.Controls.Add(this.lblPhoneTip);
            this.groupBoxPhone.Controls.Add(this.lblContactDays);
            this.groupBoxPhone.Controls.Add(this.lblPhoneNumber1);
            this.groupBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxPhone.Location = new System.Drawing.Point(12, 101);
            this.groupBoxPhone.Name = "groupBoxPhone";
            this.groupBoxPhone.Size = new System.Drawing.Size(220, 288);
            this.groupBoxPhone.TabIndex = 2;
            this.groupBoxPhone.TabStop = false;
            this.groupBoxPhone.Text = "Kontakt telefoniczny:";
            // 
            // lblPhoneNumber2
            // 
            this.lblPhoneNumber2.AutoSize = true;
            this.lblPhoneNumber2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPhoneNumber2.Location = new System.Drawing.Point(6, 73);
            this.lblPhoneNumber2.Name = "lblPhoneNumber2";
            this.lblPhoneNumber2.Size = new System.Drawing.Size(129, 20);
            this.lblPhoneNumber2.TabIndex = 4;
            this.lblPhoneNumber2.Text = "+48 503 105 800";
            // 
            // lblPhoneTip
            // 
            this.lblPhoneTip.AutoSize = true;
            this.lblPhoneTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPhoneTip.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPhoneTip.Location = new System.Drawing.Point(7, 192);
            this.lblPhoneTip.Name = "lblPhoneTip";
            this.lblPhoneTip.Size = new System.Drawing.Size(185, 60);
            this.lblPhoneTip.TabIndex = 3;
            this.lblPhoneTip.Text = "Wskazówka:\r\nprzygotuj numer zamówienia,\r\ndzięki temu szybciej odpowiemy \r\nna Twoj" +
    "e pytanie.\r\n";
            // 
            // lblContactDays
            // 
            this.lblContactDays.AutoSize = true;
            this.lblContactDays.Location = new System.Drawing.Point(6, 110);
            this.lblContactDays.Name = "lblContactDays";
            this.lblContactDays.Size = new System.Drawing.Size(159, 60);
            this.lblContactDays.TabIndex = 2;
            this.lblContactDays.Text = "pon. - pt. 8:00 - 20:00\r\nsob. 8:00 - 16:00\r\nnd. nieczynne\r\n";
            // 
            // groupBoxMail
            // 
            this.groupBoxMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxMail.Controls.Add(this.lblMailDays);
            this.groupBoxMail.Controls.Add(this.lblMailTip);
            this.groupBoxMail.Controls.Add(this.lblMail1);
            this.groupBoxMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxMail.Location = new System.Drawing.Point(551, 101);
            this.groupBoxMail.Name = "groupBoxMail";
            this.groupBoxMail.Size = new System.Drawing.Size(237, 288);
            this.groupBoxMail.TabIndex = 3;
            this.groupBoxMail.TabStop = false;
            this.groupBoxMail.Text = "Kontakt mailowy:";
            // 
            // lblMailDays
            // 
            this.lblMailDays.AutoSize = true;
            this.lblMailDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMailDays.Location = new System.Drawing.Point(6, 122);
            this.lblMailDays.Name = "lblMailDays";
            this.lblMailDays.Size = new System.Drawing.Size(183, 60);
            this.lblMailDays.TabIndex = 2;
            this.lblMailDays.Text = "Zazwyczaj odpowiadamy\r\nna wiadomości w ciągu \r\n1 - 2 dni roboczych.";
            // 
            // lblMailTip
            // 
            this.lblMailTip.AutoSize = true;
            this.lblMailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMailTip.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMailTip.Location = new System.Drawing.Point(6, 197);
            this.lblMailTip.Name = "lblMailTip";
            this.lblMailTip.Size = new System.Drawing.Size(191, 60);
            this.lblMailTip.TabIndex = 1;
            this.lblMailTip.Text = "Wskazówka:\r\nPodaj numer zamówienia w tytule\r\nwiadomości, dzięki temu \r\nszybciej o" +
    "dpowiemy.";
            // 
            // lblMail1
            // 
            this.lblMail1.AutoSize = true;
            this.lblMail1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMail1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMail1.Location = new System.Drawing.Point(1, 39);
            this.lblMail1.Name = "lblMail1";
            this.lblMail1.Size = new System.Drawing.Size(232, 16);
            this.lblMail1.TabIndex = 0;
            this.lblMail1.Text = "chx101583@student.chorzow.merito.pl";
            // 
            // Support
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxMail);
            this.Controls.Add(this.groupBoxPhone);
            this.Controls.Add(this.lblSupport);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Support";
            this.Text = "Support";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxPhone.ResumeLayout(false);
            this.groupBoxPhone.PerformLayout();
            this.groupBoxMail.ResumeLayout(false);
            this.groupBoxMail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSupport;
        private System.Windows.Forms.Label lblPhoneNumber1;
        private System.Windows.Forms.GroupBox groupBoxPhone;
        private System.Windows.Forms.Label lblPhoneTip;
        private System.Windows.Forms.Label lblContactDays;
        private System.Windows.Forms.GroupBox groupBoxMail;
        private System.Windows.Forms.Label lblMail1;
        private System.Windows.Forms.Label lblMailTip;
        private System.Windows.Forms.Label lblMailDays;
        private System.Windows.Forms.Label lblPhoneNumber2;
    }
}