namespace _408Client
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            send_button = new Button();
            chat_textbox = new RichTextBox();
            IF100_unsubscribe_button = new Button();
            IF100_subscribe_button = new Button();
            ip_textbox = new TextBox();
            port_textbox = new TextBox();
            name_textbox = new TextBox();
            connect_button = new Button();
            SPS101_chat = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            SPS101_unsubscribe_button = new Button();
            SPS101_subscribe_button = new Button();
            channel_menu = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            message_textbox = new RichTextBox();
            warning_label = new Label();
            warning_textbox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 59);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 0;
            label1.Text = " IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 111);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 156);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 2;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 256);
            label4.Name = "label4";
            label4.Size = new Size(149, 20);
            label4.TabIndex = 3;
            label4.Text = "Compose a message:";
            // 
            // send_button
            // 
            send_button.Enabled = false;
            send_button.Location = new Point(163, 473);
            send_button.Name = "send_button";
            send_button.Size = new Size(127, 29);
            send_button.TabIndex = 5;
            send_button.Text = "Send";
            send_button.UseVisualStyleBackColor = true;
            send_button.Click += send_button_Click;
            // 
            // chat_textbox
            // 
            chat_textbox.Location = new Point(351, 56);
            chat_textbox.Name = "chat_textbox";
            chat_textbox.Size = new Size(442, 446);
            chat_textbox.TabIndex = 6;
            chat_textbox.Text = "";
            // 
            // IF100_unsubscribe_button
            // 
            IF100_unsubscribe_button.Enabled = false;
            IF100_unsubscribe_button.Location = new Point(666, 15);
            IF100_unsubscribe_button.Name = "IF100_unsubscribe_button";
            IF100_unsubscribe_button.Size = new Size(127, 29);
            IF100_unsubscribe_button.TabIndex = 8;
            IF100_unsubscribe_button.Text = "Unubscribe";
            IF100_unsubscribe_button.UseVisualStyleBackColor = true;
            IF100_unsubscribe_button.Click += IF100_unsubscribe_button_Click;
            // 
            // IF100_subscribe_button
            // 
            IF100_subscribe_button.Enabled = false;
            IF100_subscribe_button.Location = new Point(664, 15);
            IF100_subscribe_button.Name = "IF100_subscribe_button";
            IF100_subscribe_button.Size = new Size(129, 29);
            IF100_subscribe_button.TabIndex = 9;
            IF100_subscribe_button.Text = "Subscribe";
            IF100_subscribe_button.UseVisualStyleBackColor = true;
            IF100_subscribe_button.Click += IF100_subscribe_button_Click;
            // 
            // ip_textbox
            // 
            ip_textbox.Location = new Point(81, 56);
            ip_textbox.Name = "ip_textbox";
            ip_textbox.Size = new Size(209, 27);
            ip_textbox.TabIndex = 10;
            // 
            // port_textbox
            // 
            port_textbox.Location = new Point(81, 108);
            port_textbox.Name = "port_textbox";
            port_textbox.Size = new Size(209, 27);
            port_textbox.TabIndex = 11;
            // 
            // name_textbox
            // 
            name_textbox.Location = new Point(81, 153);
            name_textbox.Name = "name_textbox";
            name_textbox.Size = new Size(209, 27);
            name_textbox.TabIndex = 12;
            // 
            // connect_button
            // 
            connect_button.Location = new Point(196, 201);
            connect_button.Name = "connect_button";
            connect_button.Size = new Size(94, 29);
            connect_button.TabIndex = 13;
            connect_button.Text = "Connect";
            connect_button.UseVisualStyleBackColor = true;
            connect_button.Click += connect_button_Click;
            // 
            // SPS101_chat
            // 
            SPS101_chat.Location = new Point(824, 56);
            SPS101_chat.Name = "SPS101_chat";
            SPS101_chat.Size = new Size(442, 446);
            SPS101_chat.TabIndex = 14;
            SPS101_chat.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(351, 15);
            label5.Name = "label5";
            label5.Size = new Size(313, 20);
            label5.TabIndex = 15;
            label5.Text = "========== IF 100 Channel ==========";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(824, 19);
            label6.Name = "label6";
            label6.Size = new Size(306, 20);
            label6.TabIndex = 16;
            label6.Text = "========= SPS 101 Channel =========";
            // 
            // SPS101_unsubscribe_button
            // 
            SPS101_unsubscribe_button.Enabled = false;
            SPS101_unsubscribe_button.Location = new Point(1139, 19);
            SPS101_unsubscribe_button.Name = "SPS101_unsubscribe_button";
            SPS101_unsubscribe_button.Size = new Size(127, 29);
            SPS101_unsubscribe_button.TabIndex = 18;
            SPS101_unsubscribe_button.Text = "Unubscribe";
            SPS101_unsubscribe_button.UseVisualStyleBackColor = true;
            SPS101_unsubscribe_button.Click += SPS101_unsubscribe_button_Click;
            // 
            // SPS101_subscribe_button
            // 
            SPS101_subscribe_button.Enabled = false;
            SPS101_subscribe_button.Location = new Point(1136, 19);
            SPS101_subscribe_button.Name = "SPS101_subscribe_button";
            SPS101_subscribe_button.Size = new Size(129, 29);
            SPS101_subscribe_button.TabIndex = 19;
            SPS101_subscribe_button.Text = "Subscribe";
            SPS101_subscribe_button.UseVisualStyleBackColor = true;
            SPS101_subscribe_button.Click += SPS101_subscribe_button_Click;
            // 
            // channel_menu
            // 
            channel_menu.FormattingEnabled = true;
            channel_menu.Items.AddRange(new object[] { "IF 100", "SPS 101" });
            channel_menu.Location = new Point(151, 287);
            channel_menu.Name = "channel_menu";
            channel_menu.Size = new Size(139, 28);
            channel_menu.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 290);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 21;
            label7.Text = "Select a channel:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 15);
            label8.Name = "label8";
            label8.Size = new Size(166, 20);
            label8.TabIndex = 22;
            label8.Text = "Connection information";
            // 
            // message_textbox
            // 
            message_textbox.Location = new Point(26, 334);
            message_textbox.Name = "message_textbox";
            message_textbox.Size = new Size(264, 120);
            message_textbox.TabIndex = 23;
            message_textbox.Text = "";
            // 
            // warning_label
            // 
            warning_label.AutoSize = true;
            warning_label.Location = new Point(351, 512);
            warning_label.Name = "warning_label";
            warning_label.Size = new Size(72, 20);
            warning_label.TabIndex = 24;
            warning_label.Text = "Last Info: ";
            // 
            // warning_textbox
            // 
            warning_textbox.Location = new Point(429, 509);
            warning_textbox.Name = "warning_textbox";
            warning_textbox.Size = new Size(837, 27);
            warning_textbox.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 544);
            Controls.Add(warning_textbox);
            Controls.Add(warning_label);
            Controls.Add(message_textbox);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(channel_menu);
            Controls.Add(SPS101_subscribe_button);
            Controls.Add(SPS101_unsubscribe_button);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(SPS101_chat);
            Controls.Add(connect_button);
            Controls.Add(name_textbox);
            Controls.Add(port_textbox);
            Controls.Add(ip_textbox);
            Controls.Add(IF100_subscribe_button);
            Controls.Add(IF100_unsubscribe_button);
            Controls.Add(chat_textbox);
            Controls.Add(send_button);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button send_button;
        private RichTextBox chat_textbox;
        private Button IF100_unsubscribe_button;
        private Button IF100_subscribe_button;
        private TextBox ip_textbox;
        private TextBox port_textbox;
        private TextBox name_textbox;
        private Button connect_button;
        private RichTextBox SPS101_chat;
        private Label label5;
        private Label label6;
        private Button SPS101_unsubscribe_button;
        private Button SPS101_subscribe_button;
        private ComboBox channel_menu;
        private Label label7;
        private Label label8;
        private RichTextBox message_textbox;
        private Label warning_label;
        private TextBox warning_textbox;
    }
}