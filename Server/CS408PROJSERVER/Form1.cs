using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CS408PROJSERVER
{
    public struct User
    {
        //using pulic or creating getter and setters
        public string name;
        public bool subIF;
        public bool subSP;
        public TcpClient tcpClient;

        public User(string name, TcpClient tcpClient, bool subIf, bool subSP)
        {
            this.name = name;
            this.tcpClient = tcpClient;
            this.subIF = subIf;
            this.subSP = subSP;
        }

    }
    public partial class Form1 : Form
    {
        string userName;
        private TcpListener tcpListener;
        private Thread listenerThread;
        private List<TcpClient> tcpClients;
        private List<User> users;

        public Form1()
        {
            users = new List<User>();
            tcpClients = new List<TcpClient>();
            InitializeComponent();
        }

        private void serverBtn_Click(object sender, EventArgs e)
        {
            startServer();
        }

        private void startServer()
        {
            var port = 13000;
            var hostIP = IPAddress.Parse("10.51.62.242");
            tcpListener = new TcpListener(hostIP, port);

            listenerThread = new Thread(ListenForClients);
            listenerThread.Start();

            svrRchTxtBx.AppendText("SERVER IS OPEN!!!" + "\n");
        }

        private void ListenForClients()
        {

            try
            {
                tcpListener.Start();
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    tcpClients.Add(client);
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                tcpListener.Stop();
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] messageBuffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = clientStream.Read(messageBuffer, 0, messageBuffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    string message = Encoding.ASCII.GetString(messageBuffer, 0, bytesRead);
                    string code = message.Substring(0, 3);
                    string submsg = message.Substring(4, message.Length - 4);
                    int userL = submsg.IndexOf(" ");
                    string response = "EMPTY";
                    string username = submsg.Substring(0, userL);
                    string msg = submsg.Substring(userL + 1);
                    if (code == "CNT")
                    {
                        bool isAvaible = true;
                        foreach (User user in users)
                        {
                            if (user.name == username)
                            {
                                isAvaible = false;
                            }
                        }
                        if (isAvaible)
                        {
                            userName = username;
                            users.Add(new User(username, tcpClient, false, false));
                            cntRchtxtBx.AppendText(username + "\n");
                        }
                        else if (!isAvaible)
                        {
                            response = "CER " + username + " ";
                            byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                            clientStream.Write(responseBuffer, 0, responseBuffer.Length);
                        }
                        /*foreach (User user in users)
                        {
                            if (user.name == username)
                            {
                                response = "CNT " + username;
                                NetworkStream cStream = user.tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }
                        }  */

                        this.Invoke((MethodInvoker)delegate
                        {
                            svrRchTxtBx.AppendText(username + " just connected \n");
                        });

                    }
                    else if (code == "IFS")
                    {

                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].name == username)
                            {
                                User temp = new User(username, tcpClient, true, users[i].subSP);
                                users[i] = temp;
                            }
                            if (users[i].subIF)
                            {
                                response = "IFS " + username + " ";
                                NetworkStream cStream = users[i].tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }

                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            ifRchTxtBx.AppendText(username + "\n");
                            svrRchTxtBx.AppendText(username + " just sub to IF100" + "\n");
                        });
                    }
                    else if (code == "IFU")
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].name == username)
                            {
                                User temp = new User(username, tcpClient, false, users[i].subSP);
                                users[i] = temp;
                                response = "IFU " + username + " ";
                                NetworkStream cStream = users[i].tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }
                            if (users[i].subIF)
                            {
                                response = "IFU " + username + " ";
                                NetworkStream cStream = users[i].tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }


                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            ifRchTxtBx.Text = "";
                            foreach (User user in users)
                            {
                                if (user.subIF) { ifRchTxtBx.AppendText(user.name + "\n"); }

                            }
                            //IF100 txt boxtan delete
                            //spsRchTxtBx.AppendText(username);
                            svrRchTxtBx.AppendText(username + " just unsub IF100" + "\n");
                        });
                    }
                    else if (code == "IFM")
                    {
                        foreach (User user in users)
                        {
                            if (user.subIF)
                            {
                                response = "IFR " + username + " " + msg;
                                NetworkStream cStream = user.tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }

                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            svrRchTxtBx.AppendText(username + " just sent: " + msg + " to IF101" + "\n");
                        });
                    }
                    else if (code == "SPS")
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].name == username)
                            {
                                User temp = new User(username, tcpClient, users[i].subIF, true);
                                users[i] = temp;
                            }
                            if (users[i].subSP)
                            {
                                response = "SPS " + username + " ";
                                NetworkStream cStream = users[i].tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }


                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            spsRchTxtBx.AppendText(username + "\n");
                            svrRchTxtBx.AppendText(username + " just sub to SPS101" + "\n");
                        });
                    }
                    else if (code == "SPU")
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].name == username)
                            {
                                User temp = new User(username, tcpClient, users[i].subIF, false);
                                users[i] = temp;
                                response = "SPU " + username + " ";
                                NetworkStream cStream = users[i].tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }
                            if (users[i].subSP)
                            {
                                response = "SPU " + username + " ";
                                NetworkStream cStream = users[i].tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }


                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            spsRchTxtBx.Text = "";
                            foreach (User user in users)
                            {
                                if (user.subSP)
                                {
                                    spsRchTxtBx.AppendText(user.name + "\n");
                                }
                            }
                            svrRchTxtBx.AppendText(username + " just unsub from SPS101" + "\n");
                        });
                    }
                    else if (code == "SPM")
                    {
                        foreach (User user in users)
                        {
                            if (user.subSP)
                            {
                                response = "SPR " + username + " " + msg;
                                NetworkStream cStream = user.tcpClient.GetStream();
                                byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                                cStream.Write(responseBuffer, 0, responseBuffer.Length);
                            }
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            svrRchTxtBx.AppendText(username + " just sent: " + msg + " to SPS101" + "\n");
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    break;
                }
            }

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].tcpClient == tcpClient)
                {
                    users.RemoveAt(i);
                }
            }
            ifRchTxtBx.Text = "";
            spsRchTxtBx.Text = "";
            foreach (User user in users)
            {
                if (user.subIF)
                {
                    ifRchTxtBx.AppendText(user.name + "\n");
                    string response = "IFU " + user.name + " ";
                    NetworkStream cStream = user.tcpClient.GetStream();
                    byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                    cStream.Write(responseBuffer, 0, responseBuffer.Length);
                }
                if (user.subSP)
                {
                    spsRchTxtBx.AppendText(user.name + "\n");
                    string response = "SPU " + user.name + " ";
                    NetworkStream cStream = user.tcpClient.GetStream();
                    byte[] responseBuffer = Encoding.ASCII.GetBytes(response);
                    cStream.Write(responseBuffer, 0, responseBuffer.Length);
                }

            }
            tcpClient.Close();
            cntRchtxtBx.Text = "";
            svrRchTxtBx.AppendText(userName + " disconnected\n");
            foreach (User user in users)
            {
                cntRchtxtBx.AppendText(user.name + "\n");
            }
        }

        private void clsServer_Click(object sender, EventArgs e)
        {
            closeServer();
        }
        private void closeServer()
        {
            if (tcpListener != null)
            {
                //foreach (TcpClient tcpClient in tcpClients) 
                //{
                //    NetworkStream clientStream = tcpClient.GetStream();
                //    byte[] responseBuffer = Encoding.ASCII.GetBytes("AAAABBBBCCC");
                //    clientStream.Write(responseBuffer, 0, responseBuffer.Length);
                //}
                tcpListener.Stop();
                users.Clear();
                listenerThread.Join(); // Wait for the listener thread to finish
                svrRchTxtBx.AppendText("Server CLOSED!!!! \n");
            }
            else { svrRchTxtBx.AppendText("Server Closing ERROR!!! \n"); }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //private void recieveMessage()
        //{
        //    Byte[] Buffer = new byte[1024];
        //    string recieveMsg;

        //    TcpClient client = tcpListener.AcceptTcpClient();

        //    var tcpStream = client.GetStream();

        //    int readTotal;

        //    while ((readTotal = tcpStream.Read(Buffer, 0, Buffer.Length)) != 0)
        //    {
        //        string incomingMessage = Encoding.UTF8.GetString(Buffer, 0, Buffer.Length);
        //        svrRchTxtBx.AppendText(incomingMessage);
        //    }

        //}
    }
}