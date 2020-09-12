namespace CodeAppStore.License.WinFrom
{
    partial class EncodeDecodeText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncodeDecodeText));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxEncode = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDecode = new System.Windows.Forms.RichTextBox();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encode";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(867, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Decode";
            // 
            // richTextBoxEncode
            // 
            this.richTextBoxEncode.Location = new System.Drawing.Point(12, 37);
            this.richTextBoxEncode.Name = "richTextBoxEncode";
            this.richTextBoxEncode.Size = new System.Drawing.Size(366, 280);
            this.richTextBoxEncode.TabIndex = 0;
            this.richTextBoxEncode.Text = "";
            this.richTextBoxEncode.TextChanged += new System.EventHandler(this.richTextBoxEncode_TextChanged);
            // 
            // richTextBoxDecode
            // 
            this.richTextBoxDecode.Location = new System.Drawing.Point(557, 37);
            this.richTextBoxDecode.Name = "richTextBoxDecode";
            this.richTextBoxDecode.Size = new System.Drawing.Size(372, 280);
            this.richTextBoxDecode.TabIndex = 1;
            this.richTextBoxDecode.Text = "";
            this.richTextBoxDecode.TextChanged += new System.EventHandler(this.richTextBoxDecode_TextChanged);
            // 
            // buttonEncode
            // 
            this.buttonEncode.BackColor = System.Drawing.Color.Green;
            this.buttonEncode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEncode.ForeColor = System.Drawing.Color.White;
            this.buttonEncode.Location = new System.Drawing.Point(384, 125);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(167, 43);
            this.buttonEncode.TabIndex = 3;
            this.buttonEncode.Text = "Encode >>";
            this.buttonEncode.UseVisualStyleBackColor = false;
            this.buttonEncode.Click += new System.EventHandler(this.ButtonEncode_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.BackColor = System.Drawing.Color.Indigo;
            this.buttonDecode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDecode.ForeColor = System.Drawing.Color.White;
            this.buttonDecode.Location = new System.Drawing.Point(384, 223);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(167, 43);
            this.buttonDecode.TabIndex = 5;
            this.buttonDecode.Text = "<< Decode";
            this.buttonDecode.UseVisualStyleBackColor = false;
            this.buttonDecode.Click += new System.EventHandler(this.ButtonDecode_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Maroon;
            this.buttonReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonReset.ForeColor = System.Drawing.Color.White;
            this.buttonReset.Location = new System.Drawing.Point(384, 174);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(167, 43);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(384, 76);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(167, 43);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Back To Verify";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // EncodeDecodeText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 329);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonEncode);
            this.Controls.Add(this.richTextBoxDecode);
            this.Controls.Add(this.richTextBoxEncode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncodeDecodeText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encode Decode Text";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EncodeDecodeText_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EncodeDecodeText_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EncodeDecodeText_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxEncode;
        private System.Windows.Forms.RichTextBox richTextBoxDecode;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonBack;
    }
}