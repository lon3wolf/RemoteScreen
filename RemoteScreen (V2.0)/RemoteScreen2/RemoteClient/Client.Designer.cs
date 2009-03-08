namespace RemoteClient
{
    partial class Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.ControlGroup = new System.Windows.Forms.GroupBox();
            this.FrameRate = new System.Windows.Forms.Label();
            this.SaveImage = new System.Windows.Forms.Button();
            this.CurrentRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RequestRate = new System.Windows.Forms.TrackBar();
            this.SaveSettings = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.GetImage = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.HostName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.RcvdImg = new System.Windows.Forms.PictureBox();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.ControlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RcvdImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlGroup
            // 
            this.ControlGroup.Controls.Add(this.FrameRate);
            this.ControlGroup.Controls.Add(this.SaveImage);
            this.ControlGroup.Controls.Add(this.CurrentRate);
            this.ControlGroup.Controls.Add(this.label1);
            this.ControlGroup.Controls.Add(this.RequestRate);
            this.ControlGroup.Controls.Add(this.SaveSettings);
            this.ControlGroup.Controls.Add(this.Start);
            this.ControlGroup.Controls.Add(this.Stop);
            this.ControlGroup.Controls.Add(this.GetImage);
            this.ControlGroup.Controls.Add(this.Clear);
            this.ControlGroup.Controls.Add(this.HostName);
            this.ControlGroup.Controls.Add(this.label2);
            this.ControlGroup.Controls.Add(this.IPLabel);
            this.ControlGroup.Controls.Add(this.ServerPort);
            this.ControlGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlGroup.Location = new System.Drawing.Point(0, 0);
            this.ControlGroup.Margin = new System.Windows.Forms.Padding(5);
            this.ControlGroup.Name = "ControlGroup";
            this.ControlGroup.Size = new System.Drawing.Size(207, 424);
            this.ControlGroup.TabIndex = 0;
            this.ControlGroup.TabStop = false;
            this.ControlGroup.Text = "Server Settings";
            // 
            // FrameRate
            // 
            this.FrameRate.Location = new System.Drawing.Point(6, 335);
            this.FrameRate.Name = "FrameRate";
            this.FrameRate.Size = new System.Drawing.Size(195, 21);
            this.FrameRate.TabIndex = 23;
            this.FrameRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveImage
            // 
            this.SaveImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveImage.Image = ((System.Drawing.Image)(resources.GetObject("SaveImage.Image")));
            this.SaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveImage.Location = new System.Drawing.Point(58, 369);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(76, 49);
            this.SaveImage.TabIndex = 22;
            this.SaveImage.Text = "Save";
            this.SaveImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveImage.UseVisualStyleBackColor = true;
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // CurrentRate
            // 
            this.CurrentRate.Location = new System.Drawing.Point(6, 307);
            this.CurrentRate.Name = "CurrentRate";
            this.CurrentRate.Size = new System.Drawing.Size(195, 21);
            this.CurrentRate.TabIndex = 21;
            this.CurrentRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Rate";
            // 
            // RequestRate
            // 
            this.RequestRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RequestRate.Location = new System.Drawing.Point(12, 259);
            this.RequestRate.Maximum = 30;
            this.RequestRate.Minimum = 1;
            this.RequestRate.Name = "RequestRate";
            this.RequestRate.Size = new System.Drawing.Size(178, 45);
            this.RequestRate.TabIndex = 19;
            this.RequestRate.Value = 15;
            this.RequestRate.ValueChanged += new System.EventHandler(this.RequestRate_ValueChanged);
            // 
            // SaveSettings
            // 
            this.SaveSettings.Location = new System.Drawing.Point(9, 90);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(181, 23);
            this.SaveSettings.TabIndex = 18;
            this.SaveSettings.Text = "Save Settings";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // Start
            // 
            this.Start.AccessibleDescription = "Start Client";
            this.Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start.BackgroundImage")));
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Start.Location = new System.Drawing.Point(9, 183);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 69);
            this.Start.TabIndex = 17;
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.AccessibleDescription = "Stop Client";
            this.Stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Stop.BackgroundImage")));
            this.Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Stop.Location = new System.Drawing.Point(115, 183);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 69);
            this.Stop.TabIndex = 16;
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // GetImage
            // 
            this.GetImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GetImage.BackgroundImage")));
            this.GetImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GetImage.Location = new System.Drawing.Point(35, 130);
            this.GetImage.Name = "GetImage";
            this.GetImage.Size = new System.Drawing.Size(49, 47);
            this.GetImage.TabIndex = 10;
            this.GetImage.UseVisualStyleBackColor = true;
            this.GetImage.Click += new System.EventHandler(this.GetImage_Click);
            // 
            // Clear
            // 
            this.Clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Clear.BackgroundImage")));
            this.Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Clear.Location = new System.Drawing.Point(115, 130);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(44, 47);
            this.Clear.TabIndex = 15;
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // HostName
            // 
            this.HostName.Location = new System.Drawing.Point(90, 37);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(100, 20);
            this.HostName.TabIndex = 11;
            this.HostName.Text = "127.0.0.1";
            this.HostName.Enter += new System.EventHandler(this.HostName_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port:";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(6, 40);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(78, 13);
            this.IPLabel.TabIndex = 12;
            this.IPLabel.Text = "Host Name/IP:";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(90, 63);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(100, 20);
            this.ServerPort.TabIndex = 13;
            this.ServerPort.Text = "55667";
            this.ServerPort.Enter += new System.EventHandler(this.ServerPort_Enter);
            // 
            // RcvdImg
            // 
            this.RcvdImg.BackColor = System.Drawing.Color.Black;
            this.RcvdImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RcvdImg.BackgroundImage")));
            this.RcvdImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RcvdImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RcvdImg.Cursor = System.Windows.Forms.Cursors.No;
            this.RcvdImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.RcvdImg.Location = new System.Drawing.Point(213, 0);
            this.RcvdImg.Name = "RcvdImg";
            this.RcvdImg.Padding = new System.Windows.Forms.Padding(5);
            this.RcvdImg.Size = new System.Drawing.Size(677, 424);
            this.RcvdImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RcvdImg.TabIndex = 1;
            this.RcvdImg.TabStop = false;
            // 
            // Ticker
            // 
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // FrameTimer
            // 
            this.FrameTimer.Interval = 2000;
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 424);
            this.Controls.Add(this.ControlGroup);
            this.Controls.Add(this.RcvdImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Client";
            this.Text = "XRS/Client 2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Client_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.ControlGroup.ResumeLayout(false);
            this.ControlGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RcvdImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ControlGroup;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button GetImage;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox HostName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.PictureBox RcvdImg;
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.Timer Ticker;
        private System.Windows.Forms.TrackBar RequestRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurrentRate;
        private System.Windows.Forms.Button SaveImage;
        private System.Windows.Forms.Label FrameRate;
        private System.Windows.Forms.Timer FrameTimer;

    }
}

