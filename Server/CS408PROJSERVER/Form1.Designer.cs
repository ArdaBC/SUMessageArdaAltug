namespace CS408PROJSERVER
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
            serverBtn = new Button();
            svrRchTxtBx = new RichTextBox();
            clsServer = new Button();
            ifRchTxtBx = new RichTextBox();
            spsRchTxtBx = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cntRchtxtBx = new RichTextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // serverBtn
            // 
            serverBtn.Location = new Point(33, 69);
            serverBtn.Name = "serverBtn";
            serverBtn.Size = new Size(90, 23);
            serverBtn.TabIndex = 0;
            serverBtn.Text = "Open";
            serverBtn.UseVisualStyleBackColor = true;
            serverBtn.Click += serverBtn_Click;
            // 
            // svrRchTxtBx
            // 
            svrRchTxtBx.Location = new Point(612, 69);
            svrRchTxtBx.Name = "svrRchTxtBx";
            svrRchTxtBx.Size = new Size(448, 535);
            svrRchTxtBx.TabIndex = 1;
            svrRchTxtBx.Text = "";
            // 
            // clsServer
            // 
            clsServer.Location = new Point(314, 69);
            clsServer.Name = "clsServer";
            clsServer.Size = new Size(75, 23);
            clsServer.TabIndex = 2;
            clsServer.Text = "Close";
            clsServer.UseVisualStyleBackColor = true;
            clsServer.Click += clsServer_Click;
            // 
            // ifRchTxtBx
            // 
            ifRchTxtBx.Location = new Point(31, 143);
            ifRchTxtBx.Name = "ifRchTxtBx";
            ifRchTxtBx.Size = new Size(242, 242);
            ifRchTxtBx.TabIndex = 3;
            ifRchTxtBx.Text = "";
            // 
            // spsRchTxtBx
            // 
            spsRchTxtBx.Location = new Point(314, 143);
            spsRchTxtBx.Name = "spsRchTxtBx";
            spsRchTxtBx.Size = new Size(242, 242);
            spsRchTxtBx.TabIndex = 4;
            spsRchTxtBx.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 125);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 5;
            label1.Text = "IF100 Subcirbers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 125);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 6;
            label2.Text = "SPS101 Subcirbers";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 423);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 7;
            label3.Text = "Connected";
            label3.Click += label3_Click;
            // 
            // cntRchtxtBx
            // 
            cntRchtxtBx.Location = new Point(31, 441);
            cntRchtxtBx.Name = "cntRchtxtBx";
            cntRchtxtBx.Size = new Size(536, 163);
            cntRchtxtBx.TabIndex = 10;
            cntRchtxtBx.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(806, 41);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 11;
            label4.Text = "Activity";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 631);
            Controls.Add(label4);
            Controls.Add(cntRchtxtBx);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(spsRchTxtBx);
            Controls.Add(ifRchTxtBx);
            Controls.Add(clsServer);
            Controls.Add(svrRchTxtBx);
            Controls.Add(serverBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button serverBtn;
        private RichTextBox svrRchTxtBx;
        private Button clsServer;
        private RichTextBox ifRchTxtBx;
        private RichTextBox spsRchTxtBx;
        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox cntRchtxtBx;
        private Label label4;
    }
}