namespace RemoteClient
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
            this.components = new System.ComponentModel.Container();
            this.GetImage = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.RcvdImg = new System.Windows.Forms.PictureBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.FrameRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.IPList = new System.Windows.Forms.ComboBox();
            this.RefreshIPs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RcvdImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameRate)).BeginInit();
            this.SuspendLayout();
            // 
            // GetImage
            // 
            this.GetImage.Location = new System.Drawing.Point(36, 120);
            this.GetImage.Name = "GetImage";
            this.GetImage.Size = new System.Drawing.Size(75, 23);
            this.GetImage.TabIndex = 0;
            this.GetImage.Text = "Get Image";
            this.GetImage.UseVisualStyleBackColor = true;
            this.GetImage.Click += new System.EventHandler(this.GetImage_Click);
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(36, 67);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(100, 20);
            this.IP.TabIndex = 1;
            this.IP.Text = "127.0.0.1";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(10, 70);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(20, 13);
            this.IPLabel.TabIndex = 2;
            this.IPLabel.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(36, 93);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(100, 20);
            this.ServerPort.TabIndex = 3;
            this.ServerPort.Text = "55667";
            // 
            // RcvdImg
            // 
            this.RcvdImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.RcvdImg.Location = new System.Drawing.Point(142, 0);
            this.RcvdImg.Name = "RcvdImg";
            this.RcvdImg.Size = new System.Drawing.Size(782, 356);
            this.RcvdImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RcvdImg.TabIndex = 5;
            this.RcvdImg.TabStop = false;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(36, 150);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Ticker
            // 
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // FrameRate
            // 
            this.FrameRate.Location = new System.Drawing.Point(36, 242);
            this.FrameRate.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FrameRate.Name = "FrameRate";
            this.FrameRate.Size = new System.Drawing.Size(42, 20);
            this.FrameRate.TabIndex = 7;
            this.FrameRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FrameRate.ValueChanged += new System.EventHandler(this.FrameRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Refresh Rate:";
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(36, 179);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 9;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // IPList
            // 
            this.IPList.FormattingEnabled = true;
            this.IPList.Location = new System.Drawing.Point(12, 12);
            this.IPList.Name = "IPList";
            this.IPList.Size = new System.Drawing.Size(121, 21);
            this.IPList.TabIndex = 10;
            this.IPList.SelectedIndexChanged += new System.EventHandler(this.IPList_SelectedIndexChanged);
            // 
            // RefreshIPs
            // 
            this.RefreshIPs.BackColor = System.Drawing.Color.Transparent;
            this.RefreshIPs.Image = global::RemoteClient.Properties.Resources.Loading;
            this.RefreshIPs.Location = new System.Drawing.Point(107, 38);
            this.RefreshIPs.Name = "RefreshIPs";
            this.RefreshIPs.Size = new System.Drawing.Size(26, 23);
            this.RefreshIPs.TabIndex = 11;
            this.RefreshIPs.UseVisualStyleBackColor = false;
            this.RefreshIPs.Click += new System.EventHandler(this.RefreshIPs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 356);
            this.Controls.Add(this.RefreshIPs);
            this.Controls.Add(this.IPList);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FrameRate);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.RcvdImg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerPort);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.GetImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.RcvdImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetImage;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.PictureBox RcvdImg;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Timer Ticker;
        private System.Windows.Forms.NumericUpDown FrameRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.ComboBox IPList;
        private System.Windows.Forms.Button RefreshIPs;

    }
}

