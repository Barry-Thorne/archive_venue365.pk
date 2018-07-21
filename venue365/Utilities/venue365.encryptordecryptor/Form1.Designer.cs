namespace venue365.encryptordecryptor
{
    partial class Form1
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
            this.txtInputString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncodedString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDecodedString = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input String: ";
            // 
            // txtInputString
            // 
            this.txtInputString.Location = new System.Drawing.Point(162, 6);
            this.txtInputString.Multiline = true;
            this.txtInputString.Name = "txtInputString";
            this.txtInputString.Size = new System.Drawing.Size(600, 90);
            this.txtInputString.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Encoded String: ";
            // 
            // txtEncodedString
            // 
            this.txtEncodedString.Location = new System.Drawing.Point(162, 114);
            this.txtEncodedString.Multiline = true;
            this.txtEncodedString.Name = "txtEncodedString";
            this.txtEncodedString.Size = new System.Drawing.Size(600, 90);
            this.txtEncodedString.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Decoded String: ";
            // 
            // txtDecodedString
            // 
            this.txtDecodedString.Location = new System.Drawing.Point(162, 221);
            this.txtDecodedString.Multiline = true;
            this.txtDecodedString.Name = "txtDecodedString";
            this.txtDecodedString.Size = new System.Drawing.Size(600, 90);
            this.txtDecodedString.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Decrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(685, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "Encrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDecodedString);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEncodedString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInputString);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Encryptor Decryptor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncodedString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecodedString;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

