namespace Server
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
            listBox1 = new ListBox();
            tbHost = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbPort = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Top;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(476, 349);
            listBox1.TabIndex = 0;
            // 
            // tbHost
            // 
            tbHost.Location = new Point(177, 367);
            tbHost.Name = "tbHost";
            tbHost.Size = new Size(115, 23);
            tbHost.TabIndex = 1;
            tbHost.Text = "localhost";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 370);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 2;
            label1.Text = "HOST";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 409);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 4;
            label2.Text = "PORT";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(177, 406);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(115, 23);
            tbPort.TabIndex = 3;
            tbPort.Text = "8090";
            // 
            // button1
            // 
            button1.Location = new Point(14, 380);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "StartListen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(328, 380);
            button2.Name = "button2";
            button2.Size = new Size(136, 23);
            button2.TabIndex = 6;
            button2.Text = "StartTCPListener";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 512);
            Controls.Add(button2);
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

        private ListBox listBox1;
        private TextBox tbHost;
        private Label label1;
        private Label label2;
        private TextBox tbPort;
        private Button button1;
        private Button button2;
    }
}