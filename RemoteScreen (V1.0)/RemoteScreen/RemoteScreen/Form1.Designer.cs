namespace RemoteScreen
{
    partial class RemoteScreen
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
            this.CaptureButton = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CaptureButton
            // 
            this.CaptureButton.Location = new System.Drawing.Point(66, 9);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(75, 23);
            this.CaptureButton.TabIndex = 0;
            this.CaptureButton.Text = "Capture";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.Capture_Click);
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(32, 118);
            this.Register.MinimumSize = new System.Drawing.Size(20, 20);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(176, 178);
            this.Register.TabIndex = 1;
            this.Register.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(214, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 91);
            this.label1.TabIndex = 2;
            this.label1.Text = "::Redundant:: | This Form remains hidden, and is of little use now. | It is ok if" +
                " you want to remove it, but remove dependency first";
            // 
            // RemoteScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 330);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CaptureButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoteScreen";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Remote Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CaptureButton;
        private System.Windows.Forms.WebBrowser Register;
        private System.Windows.Forms.Label label1;
    }
}

