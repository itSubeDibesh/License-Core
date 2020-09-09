namespace CodeAppStore.License.WinFrom
{
    partial class Generate_Existing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generate_Existing));
            this.textBoxProjectCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClientCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxCombinedLicense = new System.Windows.Forms.RichTextBox();
            this.buttonGenerateNewLicense = new System.Windows.Forms.Button();
            this.buttonBackToVerify = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerIssued = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerExpired = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxCombinedEncryptedLicense = new System.Windows.Forms.RichTextBox();
            this.textBoxCertificate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEncryptedCertificate = new System.Windows.Forms.TextBox();
            this.panelSeperator = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEncryptedLicense = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxProjectCode
            // 
            this.textBoxProjectCode.Location = new System.Drawing.Point(99, 44);
            this.textBoxProjectCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxProjectCode.Name = "textBoxProjectCode";
            this.textBoxProjectCode.Size = new System.Drawing.Size(293, 23);
            this.textBoxProjectCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Project Code :";
            // 
            // textBoxClientCode
            // 
            this.textBoxClientCode.Location = new System.Drawing.Point(99, 13);
            this.textBoxClientCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxClientCode.Name = "textBoxClientCode";
            this.textBoxClientCode.Size = new System.Drawing.Size(293, 23);
            this.textBoxClientCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Client Code :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comb License :";
            // 
            // richTextBoxCombinedLicense
            // 
            this.richTextBoxCombinedLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxCombinedLicense.Location = new System.Drawing.Point(99, 208);
            this.richTextBoxCombinedLicense.Name = "richTextBoxCombinedLicense";
            this.richTextBoxCombinedLicense.Size = new System.Drawing.Size(293, 77);
            this.richTextBoxCombinedLicense.TabIndex = 5;
            this.richTextBoxCombinedLicense.Text = "";
            // 
            // buttonGenerateNewLicense
            // 
            this.buttonGenerateNewLicense.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonGenerateNewLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGenerateNewLicense.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateNewLicense.Location = new System.Drawing.Point(0, 540);
            this.buttonGenerateNewLicense.Name = "buttonGenerateNewLicense";
            this.buttonGenerateNewLicense.Size = new System.Drawing.Size(224, 44);
            this.buttonGenerateNewLicense.TabIndex = 3;
            this.buttonGenerateNewLicense.Text = "Generate New License";
            this.buttonGenerateNewLicense.UseVisualStyleBackColor = false;
            this.buttonGenerateNewLicense.Click += new System.EventHandler(this.ButtonGenerateNewLicense_Click);
            // 
            // buttonBackToVerify
            // 
            this.buttonBackToVerify.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonBackToVerify.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBackToVerify.ForeColor = System.Drawing.Color.White;
            this.buttonBackToVerify.Location = new System.Drawing.Point(235, 540);
            this.buttonBackToVerify.Name = "buttonBackToVerify";
            this.buttonBackToVerify.Size = new System.Drawing.Size(157, 43);
            this.buttonBackToVerify.TabIndex = 6;
            this.buttonBackToVerify.Text = "Back To Verify";
            this.buttonBackToVerify.UseVisualStyleBackColor = false;
            this.buttonBackToVerify.Click += new System.EventHandler(this.ButtonVerify_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Issued :";
            // 
            // dateTimePickerIssued
            // 
            this.dateTimePickerIssued.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerIssued.Location = new System.Drawing.Point(99, 74);
            this.dateTimePickerIssued.Name = "dateTimePickerIssued";
            this.dateTimePickerIssued.Size = new System.Drawing.Size(293, 23);
            this.dateTimePickerIssued.TabIndex = 7;
            // 
            // dateTimePickerExpired
            // 
            this.dateTimePickerExpired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerExpired.Location = new System.Drawing.Point(99, 105);
            this.dateTimePickerExpired.Name = "dateTimePickerExpired";
            this.dateTimePickerExpired.Size = new System.Drawing.Size(293, 23);
            this.dateTimePickerExpired.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Expired :";
            // 
            // richTextBoxCombinedEncryptedLicense
            // 
            this.richTextBoxCombinedEncryptedLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxCombinedEncryptedLicense.Location = new System.Drawing.Point(99, 291);
            this.richTextBoxCombinedEncryptedLicense.Name = "richTextBoxCombinedEncryptedLicense";
            this.richTextBoxCombinedEncryptedLicense.Size = new System.Drawing.Size(293, 77);
            this.richTextBoxCombinedEncryptedLicense.TabIndex = 5;
            this.richTextBoxCombinedEncryptedLicense.Text = "";
            // 
            // textBoxCertificate
            // 
            this.textBoxCertificate.Location = new System.Drawing.Point(100, 145);
            this.textBoxCertificate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCertificate.Name = "textBoxCertificate";
            this.textBoxCertificate.Size = new System.Drawing.Size(293, 23);
            this.textBoxCertificate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Certificate :";
            // 
            // textBoxEncryptedCertificate
            // 
            this.textBoxEncryptedCertificate.Location = new System.Drawing.Point(99, 176);
            this.textBoxEncryptedCertificate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEncryptedCertificate.Name = "textBoxEncryptedCertificate";
            this.textBoxEncryptedCertificate.Size = new System.Drawing.Size(293, 23);
            this.textBoxEncryptedCertificate.TabIndex = 4;
            // 
            // panelSeperator
            // 
            this.panelSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeperator.BackColor = System.Drawing.Color.Black;
            this.panelSeperator.Location = new System.Drawing.Point(5, 134);
            this.panelSeperator.Name = "panelSeperator";
            this.panelSeperator.Size = new System.Drawing.Size(400, 5);
            this.panelSeperator.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 376);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "License :";
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxLicense.Location = new System.Drawing.Point(99, 374);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.Size = new System.Drawing.Size(293, 77);
            this.richTextBoxLicense.TabIndex = 5;
            this.richTextBoxLicense.Text = "";
            // 
            // richTextBoxEncryptedLicense
            // 
            this.richTextBoxEncryptedLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxEncryptedLicense.Location = new System.Drawing.Point(99, 457);
            this.richTextBoxEncryptedLicense.Name = "richTextBoxEncryptedLicense";
            this.richTextBoxEncryptedLicense.Size = new System.Drawing.Size(293, 77);
            this.richTextBoxEncryptedLicense.TabIndex = 5;
            this.richTextBoxEncryptedLicense.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 176);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Encrypted :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 293);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Encrypted :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 457);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Encrypted :";
            // 
            // Generate_Existing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 595);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBoxEncryptedLicense);
            this.Controls.Add(this.richTextBoxLicense);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelSeperator);
            this.Controls.Add(this.textBoxEncryptedCertificate);
            this.Controls.Add(this.richTextBoxCombinedEncryptedLicense);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerExpired);
            this.Controls.Add(this.dateTimePickerIssued);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonBackToVerify);
            this.Controls.Add(this.buttonGenerateNewLicense);
            this.Controls.Add(this.richTextBoxCombinedLicense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxClientCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProjectCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCertificate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Generate_Existing";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate License Using Existing Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxProjectCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxClientCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxCombinedLicense;
        private System.Windows.Forms.Button buttonGenerateNewLicense;
        private System.Windows.Forms.Button buttonBackToVerify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssued;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpired;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxCombinedEncryptedLicense;
        private System.Windows.Forms.TextBox textBoxCertificate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEncryptedCertificate;
        private System.Windows.Forms.Panel panelSeperator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
        private System.Windows.Forms.RichTextBox richTextBoxEncryptedLicense;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}