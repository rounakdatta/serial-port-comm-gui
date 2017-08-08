using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Get_Port.Items.AddRange(SerialPort.GetPortNames());
            Get_BR.Enabled = false; //change this to 'false' at lab
            e_Field.Enabled = false;
            M_Field.Enabled = false;
            Send_Button.Enabled = false;
            Receive_Button.Enabled = false;
        }

        /*static class serial
        {
            public static string Port_Name = Get_Port.SelectedItem.ToString(); //get port name
            int Baud_Rate = Convert.ToInt32(Get_BR.SelectedItem); //get the baud rate
            public static SerialPort COMport = new SerialPort(Port_Name, Baud_Rate);
        }*/

        public string checksum(string a) //checksum function
        {
            if (a.Length < 32) //total length needs to be 32
            {
                int oddsum = 0;
                int evensum = 0;


                for (int i = a.Length - 1; i >= 1; i -= 2) //sum of the odd positioned digits
                {
                    oddsum += (Convert.ToInt32(a[i]));
                }

                for (int i = a.Length - 2; i >= 1; i -= 2) //sum of the (even positioned digits * 2)
                {
                    evensum += ((Convert.ToInt32(a[i]) * 2));
                }

                int sum = oddsum + evensum; //the sums are summed

                if (sum > 9) //if sum > 9, decrease 9
                    sum -= 9;


                if (sum % 10 == 0) //getting the checksum char
                    a += '0';
                else
                    a += '1';

                a = checksum(a); //send for checksum again for getting 32nd char
                return a;
            }
            else
                return a; //if all 32 chars are present, return
        }

        private void Go_Button_Click(object sender, EventArgs e)
        {
            if (e_Field.Text[1] == '.' && M_Field.Text[1] == '.')// && !string.IsNullOrWhiteSpace(e_Field.Text) && !string.IsNullOrWhiteSpace(M_Field.Text)) 
            {
                int i, j;
                char[] data = new char[30]; //for sending from PC to μ the 'type' character should be '3'
                data[0] = '3';

                string temp = e_Field.Text.Replace(@".", @""); //remove decimal point and append '0' at end
                if (temp.Length < 5)
                    temp += "0";

                string temp2 = M_Field.Text.Replace(@".", @""); //remove decimal point and append '0' at end
                if (temp2.Length < 5)
                    temp2 += "0";

                for (i = 1; i <= temp.Length; i++) //putting A into string
                {
                    data[i] = temp[i - 1];
                }
                while (i < 6) //if 5 chars aren't complete append extra '0's
                {
                    data[i] = '0';
                    i++;
                }

                for (j = i; j < (temp2.Length + i); j++) //putting B into string
                {
                    data[j] = temp2[j - i];
                }
                while (j < 5 + i) //if 5 chars aren't complete append extra '0's
                {
                    data[j] = '0';
                    j++;
                }

                for (int k = j; k < 19 + j; k++) //all 19 chars in the middle need to be '0's
                    data[k] = '0';


                string s = new string(data); //converting char array data[] into string cval
                string cval = checksum(s); //passing cval for checksum calculation

                Log_Box.Text = cval; //2 checksum chars are appended to the end of the string and displayed in log

                string Port_Name = Get_Port.SelectedItem.ToString(); //get port name
                int Baud_Rate = Convert.ToInt32(Get_BR.SelectedItem); //get the baud rate

                char[] feedback = new char[32];

                SerialPort COMport = new SerialPort(Port_Name, Baud_Rate); //open a new serial port for the given port and baudrate

                COMport.DtrEnable = false;

                COMport.Open();

                Thread.Sleep(300);

                    if (COMport.IsOpen == true)
                    {
                        COMport.WriteLine(cval);

                        COMport.ReadTimeout = 3500;

                        try
                        {
                            //feedback = COMport.ReadLine();
                            COMport.Read(feedback, 0, 32);
                            if (feedback[0] != '2')
                            {
                                Go_Button_Click(sender, e);
                            }
                        }
                        catch (TimeoutException SerialTimeOutException)
                        {
                            MessageBox.Show("Feedback TimeOut!");
                            MessageBox.Show(SerialTimeOutException.ToString());
                        }

                        COMport.Close();
                        Log_Box.Text = "Written to PORT " + Port_Name;
                        Receive_Button.Enabled = true;
                    }
                    else
                    {
                        Log_Box.Text = "Unable to write to PORT";
                    }
                

            }
            else
                MessageBox.Show("*Follow scientific notation\n*Enter value within constraints", "Wrong input");
            }

        private void A_Field_TextChanged(object sender, EventArgs e)
        {
                Send_Button.Enabled = true;
                //Receive_Button.Enabled = true;
        }

        private void Process_Button_Click(object sender, EventArgs e)
        {
                string Port_Name = Get_Port.SelectedItem.ToString(); //get port name
                int Baud_Rate = Convert.ToInt32(Get_BR.SelectedItem); //get the baud rate

                char[] raw = new char[32];

                SerialPort COMport = new SerialPort(Port_Name, Baud_Rate); //open a new serial port for the given port and baudrate

                COMport.DtrEnable = false;

                COMport.ReadTimeout = 3500; //timeout time for reading is 3.5s

                COMport.Open();

                Thread.Sleep(300);

                try
                {
                    if (COMport.IsOpen == true)
                    {
                        //receive_data = COMport.ReadLine();
                        COMport.Read(raw, 0, 32);

                        string receive_data = raw.ToString();

                        if ((checksum(receive_data.Substring(0, 30)) == receive_data.Substring(0, 32)) && receive_data[0] =='4') //checksum validation
                        {
                            string feedback = "200000000000000000000000000000";
                            feedback = checksum(feedback);
                            COMport.WriteLine(feedback);
                        }
                        else
                        {
                            MessageBox.Show("Checksum failed"); //if checksum char(s) validation fails, show fail
                        }


                        COMport.Close();
                        Log_Box.Text = "Received from PORT " + Port_Name;
                        Receive_Button.Enabled = true;
                    }
                }
                catch (TimeoutException SerialTimeOutException)
                {
                    MessageBox.Show("Read TimeOut!");
                    MessageBox.Show(SerialTimeOutException.ToString());
                }

                string received_data = raw.ToString();

                float x = (float)Convert.ToInt32(received_data.Substring(1, 5)) / (float)10000; //extract first number
                float y = (float)Convert.ToInt32(received_data.Substring(6, 5)) / (float)10000; //extract second number
                
                th_Field.Text = x.ToString();
                bige_Field.Text = y.ToString();
            
        }

        private void Get_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_BR.Enabled = true;
            Log_Box.Text = Get_Port.SelectedItem.ToString() + " selected" ;
        }

        private void Get_BR_SelectedIndexChanged(object sender, EventArgs e)
        {
            e_Field.Enabled = true;
            M_Field.Enabled = true;
            Log_Box.Text = Get_BR.SelectedItem.ToString() + " bps selected";

        }

        private void Health_Button_Click(object sender, EventArgs e)
        {
            string Port_Name = Get_Port.SelectedItem.ToString(); //get port name
            int Baud_Rate = Convert.ToInt32(Get_BR.SelectedItem); //get the baud rate

            char[] feedbackchar = new char[32];

            SerialPort COMport = new SerialPort(Port_Name, Baud_Rate); //open a new serial port for the given port and baudrate

            COMport.DtrEnable = false;

            COMport.Open();

            Thread.Sleep(300);

            if (COMport.IsOpen == true)
            {
                string reqh = "500000000000000000000000000000";
                reqh = checksum(reqh);
                COMport.WriteLine(reqh);

                COMport.ReadTimeout = 3500;

                try
                {
                    COMport.Read(feedbackchar, 0, 32);
                    string feedback = feedbackchar.ToString();

                    if (feedback[0] != '6' && (checksum(feedback.Substring(0, 30)) != feedback.Substring(0, 32)))
                    {
                        Health_Button_Click(sender, e);
                    }
                    else
                    {
                        string feedback2 = "20000000000000000000000000000000";
                        COMport.WriteLine(feedback2);


                        Time_Field.Text = feedback.Substring(0, 12);
                        Health_Box.Text = feedback.Substring(10, 3) + "\n" + feedback.Substring(13, 3) + "\n" + feedback.Substring(16, 3) + "\n" + feedback.Substring(19, 3);
                    }
                }
                catch (TimeoutException SerialTimeOutException)
                {
                    MessageBox.Show("Feedback TimeOut!");
                    MessageBox.Show(SerialTimeOutException.ToString());
                }

                COMport.Close();
                Log_Box.Text = "Written to PORT " + Port_Name;
                Receive_Button.Enabled = true;
            }
            else
            {
                Log_Box.Text = "Unable to write to PORT";
            }
        }

    }

        
}
