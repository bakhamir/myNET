namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "SendToServer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "PORT";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(182, 410);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(115, 23);
            this.tbPort.TabIndex = 9;
            this.tbPort.Text = "8090";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "HOST";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(182, 371);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(115, 23);
            this.tbHost.TabIndex = 7;
            this.tbHost.Text = "localhost";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(531, 349);
            this.listBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Message";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(197, 449);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(115, 23);
            this.tbMessage.TabIndex = 12;
            this.tbMessage.Text = "Hello STEP";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "SendToTCPServer";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 507);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label label2;
        private TextBox tbPort;
        private Label label1;
        private TextBox tbHost;
        private ListBox listBox1;
        private Label label3;
        private TextBox tbMessage;
        private Button button2;
    }
}