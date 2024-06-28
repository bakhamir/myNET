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
            button1 = new Button();
            label2 = new Label();
            tbPort = new TextBox();
            label1 = new Label();
            tbHost = new TextBox();
            listBox1 = new ListBox();
            label3 = new Label();
            tbMessage = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(25, 374);
            button1.Name = "button1";
            button1.Size = new Size(95, 23);
            button1.TabIndex = 11;
            button1.Text = "SendToServer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 413);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 10;
            label2.Text = "PORT";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(182, 410);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(115, 23);
            tbPort.TabIndex = 9;
            tbPort.Text = "8090";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 374);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 8;
            label1.Text = "HOST";
            // 
            // tbHost
            // 
            tbHost.Location = new Point(182, 371);
            tbHost.Name = "tbHost";
            tbHost.Size = new Size(115, 23);
            tbHost.TabIndex = 7;
            tbHost.Text = "localhost";
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Top;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(531, 349);
            listBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 452);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 13;
            label3.Text = "Message";
            // 
            // tbMessage
            // 
            tbMessage.Location = new Point(197, 449);
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(115, 23);
            tbMessage.TabIndex = 12;
            tbMessage.Text = "Hello STEP";
            // 
            // button2
            // 
            button2.Location = new Point(360, 374);
            button2.Name = "button2";
            button2.Size = new Size(137, 23);
            button2.TabIndex = 14;
            button2.Text = "SendToTCPServer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 507);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(tbMessage);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(tbPort);
            Controls.Add(label1);
            Controls.Add(tbHost);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
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