using Microsoft.VisualBasic.Logging;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace _408Client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        bool msgSend = false;
        string userName = string.Empty;
        Socket clientSocket;

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[1024]; //1024 yap
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);

                    string code = incomingMessage.Substring(0, 3);
                    string submsg = incomingMessage.Substring(4, incomingMessage.Length - 4);
                    int userL = submsg.IndexOf(" ");
                    string username = submsg.Substring(0, userL);
                    string msg = submsg.Substring(userL + 1);

                    //incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\n"));

                    if (incomingMessage != "")
                    {
                        if (code == "IFR")
                        {
                            chat_textbox.AppendText("[" + username + "]: " + msg + "\n");
                        }
                        else if (code == "SPR")
                        {
                            SPS101_chat.AppendText("[" + username + "]: " + msg + "\n");
                        }
                        else if (code == "IFS")
                        {
                            chat_textbox.AppendText(" * " + username + " just subscribed to IF 100!\n");
                            IF100_unsubscribe_button.Enabled = true;
                        }
                        else if (code == "IFU")
                        {
                            chat_textbox.AppendText(" * " + username + " unsubscribed from IF 100.\n");
                            IF100_subscribe_button.Enabled = true;
                        }
                        else if (code == "SPS")
                        {
                            SPS101_chat.AppendText(" * " + username + " just subscribed to SPS 101!\n");
                            SPS101_unsubscribe_button.Enabled = true;
                        }
                        else if (code == "SPU")
                        {
                            SPS101_chat.AppendText(" * " + username + " unsubscribed from SPS 101.\n");
                            SPS101_subscribe_button.Enabled = true;
                        }
                        else if (code == "CER")
                        {
                            warning_textbox.Text = username + " is already taken!\n";
                        }
                        else
                        {
                            warning_textbox.Text = "Faulty server response!\n";
                        }

                    }
                    terminating = true;
                }
                catch
                {
                    if (!terminating)
                    {
                        warning_textbox.Text = "The server has disconnected!\n";
                        connect_button.Enabled = true;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = ip_textbox.Text;
            userName = name_textbox.Text;
            int portNum;

            if (userName != string.Empty && !userName.Contains(" "))
            {
                if (Int32.TryParse(port_textbox.Text, out portNum))
                {
                    try
                    {
                        clientSocket.Connect(IP, portNum);
                        connected = true;

                        string message = "CNT " + userName + " ";

                        if (message.Length <= 1024)
                        {
                            Byte[] buffer = Encoding.Default.GetBytes(message);
                            clientSocket.Send(buffer);
                        }

                        warning_textbox.Text = "Connected to the server!\n";

                        connect_button.Enabled = false;
                        send_button.Enabled = true;
                        IF100_subscribe_button.Enabled = true;
                        IF100_unsubscribe_button.Enabled = true;
                        SPS101_subscribe_button.Enabled = true;
                        SPS101_unsubscribe_button.Enabled = true;

                        Thread receiveThread = new Thread(Receive);
                        receiveThread.Start();

                    }
                    catch
                    {
                        warning_textbox.Text = "Could not connect to the server!\n";
                    }
                }
                else
                {
                    warning_textbox.Text = "Check the port!\n";
                }
            }
            else
            {
                warning_textbox.Text = "Enter a valid username! Remember, no spaces allowed.\n";
            }
        }

        private void IF100_subscribe_button_Click(object sender, EventArgs e)
        {
            string message = "IFS " + userName + " ";

            if (message.Length <= 1024 && connected)              
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }

            IF100_subscribe_button.Visible = false;
            IF100_unsubscribe_button.Visible = true;
            IF100_unsubscribe_button.Enabled = false;
            //Thread.Sleep(1000);
            //IF100_unsubscribe_button.Enabled = true;
        }

        private void IF100_unsubscribe_button_Click(object sender, EventArgs e)
        {

            string message = "IFU " + userName + " ";

            if (message.Length <= 1024 && connected)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }

            IF100_subscribe_button.Visible = true;
            IF100_unsubscribe_button.Visible = false;
            IF100_subscribe_button.Enabled = false;
            //Thread.Sleep(1000);
            //IF100_subscribe_button.Enabled = true;
        }

        private void send_button_Click(object sender, EventArgs e)
        {

            if (channel_menu.Text != string.Empty)
            {
          
                string message = "";

                if (channel_menu.Text == "SPS 101" && SPS101_subscribe_button.Visible == false)
                {
                    message = "SPM " + userName + " " + message_textbox.Text;
                }
                else if (channel_menu.Text == "IF 100" && IF100_subscribe_button.Visible == false)
                {
                    message = "IFM " + userName + " " + message_textbox.Text;
                }
                else
                {
                    warning_textbox.Text = "If you got this error, may God help you.";
                }

                if (message != "" && message.Length <= 1024 && connected)
                {
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                }

                send_button.Enabled = false;
                Thread.Sleep(1000);
                send_button.Enabled = true;

            }
            else
            {
                warning_textbox.AppendText("Choose a channel you subscribed to first!\n");
            }

        }

        private void SPS101_unsubscribe_button_Click(object sender, EventArgs e)
        {
            string message = "SPU " + userName + " ";

            if (message.Length <= 1024 && connected) //1024 byte yap
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }

            SPS101_subscribe_button.Visible = true;
            SPS101_unsubscribe_button.Visible = false;
            SPS101_subscribe_button.Enabled = false;
            //Thread.Sleep(1000);
            //SPS101_subscribe_button.Enabled = true;
        }

        private void SPS101_subscribe_button_Click(object sender, EventArgs e)
        {
            string message = "SPS " + userName + " ";

            if (message.Length <= 1024 && connected)              
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }

            SPS101_subscribe_button.Visible = false;
            SPS101_unsubscribe_button.Visible = true;
            SPS101_unsubscribe_button.Enabled = false;
            //Thread.Sleep(1000);
            //SPS101_unsubscribe_button.Enabled = true;

        }
    }
}