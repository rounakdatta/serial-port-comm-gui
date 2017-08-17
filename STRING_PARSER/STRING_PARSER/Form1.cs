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
            connect_button.Enabled = false;
            Send_Button.Enabled = false;
        } // ctor

        public uint checksum(char[] buffer, int len = 30) //checksum function
        {
            const int CRC_PRESET = 0xff;
            const int CRC_POLYNOM = 0x9c;
            int i = 0, j = 0;
            uint crc = CRC_PRESET;

            for (i = 0; i < len; i++)
            {
                crc ^= buffer[i];
                for (j = 0; j < 8; j++)
                {
                    if ((crc & 0x01) != 0)
                    {
                        crc = (crc >> 1) ^ CRC_POLYNOM;
                    }
                    else
                    {
                        crc = (crc >> 1);
                    }
                }
            }
            return crc;
        } // checksum 

        char int2hex(uint dec)
        {
            if (dec >= 0 && dec < 10)
            {
                return (char)(dec + 48);
            }
            else if (dec >= 10 && dec <= 15)
                return (char)(dec - 10 + 97);
            else
                return 'f';
        } // int2hex

        string gettime(int seconds)
        {
            int min = seconds / 60;
            seconds = seconds % 60;
            string timestr = min.ToString("00") + ":" + seconds.ToString("00");
            return timestr;
        }

        public bool writeport(char[] data, int len)
        {

            try
            {
                COMport.Write(data, 0, len);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                return false;
            }
            return true;
        } // writeport


        private void Go_Button_Click(object sender, EventArgs e)
        {
            if (e_Field.Text[1] == '.' && M_Field.Text[1] == '.' && !string.IsNullOrWhiteSpace(e_Field.Text) && !string.IsNullOrWhiteSpace(M_Field.Text))
            {
                int i, j;
                char[] data = new char[32]; //for sending from PC to µ the 'type' character should be '3'
                data[0] = '3';

                string temp = e_Field.Text.Replace(@".", @""); //remove decimal point and append '0' at end


                string temp2 = M_Field.Text.Replace(@".", @""); //remove decimal point and append '0' at end


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
                while (j < 6 + i) //if 5 chars aren't complete append extra '0's
                {
                    data[j] = '0';
                    j++;
                }

                for (int k = j; k < 18 + j; k++) //all 19 chars in the middle need to be '0's
                    data[k] = '0';

                uint chkval = checksum(data);

                chkval = chkval % 256;
                data[30] = int2hex(chkval / 16);
                data[31] = int2hex(chkval % 16);



                if (writeport(data, 32) == true)
                {
                    Log_Box.Text = "Written to PORT " + string.Join("", data);
                }
                else
                {
                    // Go_Button_Click(sender, e);
                    Log_Box.Text = "Unable to write to PORT";
                }
            } // if 

        } // go btn handler

        private void A_Field_TextChanged(object sender, EventArgs e)
        {
            Send_Button.Enabled = true;
            //Receive_Button.Enabled = true;
        }

        private void Get_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_BR.Enabled = true;
            Log_Box.Text = Get_Port.SelectedItem.ToString() + " selected";
        }

        private void Get_BR_SelectedIndexChanged(object sender, EventArgs e)
        {
            e_Field.Enabled = true;
            M_Field.Enabled = true;
            connect_button.Enabled = true;
            Log_Box.Text = Get_BR.SelectedItem.ToString() + " bps selected";
        }


        private void Health_Button_Click(object sender, EventArgs e)
        {
            char[] feedbackchar = new char[32];
            if (COMport.IsOpen == true)
            {
                string healthreq = "500000000000000000000000000000";
                char[] reqh = new char[32];
                for (int i = 0; i < 30; i++)
                {
                    reqh[i] = healthreq[i];
                }
                char[] ckval = new char[2];


                //Again getting the checksum of received string
                uint chkval = checksum(reqh);

                chkval = chkval % 256;
                ckval[0] = int2hex(chkval / 16);
                ckval[1] = int2hex(chkval % 16);

                reqh[30] = ckval[0];
                reqh[31] = ckval[1];

                try
                {
                    Thread.Sleep(300);
                    COMport.Write(reqh, 0, 32);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                var CurDate= DateTime.Now;
                Time_Field.Text = CurDate.Hour.ToString() + " : " + CurDate.Minute.ToString() + " : " + CurDate.Millisecond.ToString();

            }
            else
            {
                Log_Box.Text = "Unable to write to PORT";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Receive_Button_Click(object sender, EventArgs e)
        {

        }

        private void flushbutton_Click(object sender, EventArgs e)
        {
            try
            {
                COMport.DiscardInBuffer();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void parsePacket(string idata1)
        {
            if (idata1[0] == '1')
                MessageBox.Show("Checksum fail");

            if (idata1[0] == '4')
            {
                //Splitting string into two parts 30 bytes and 2 bytes for checksum
                char[] result1 = idata1.ToCharArray();


                // char[] rec2 = receive_data.Substring(30, 31).ToCharArray();
                char[] new_result2 = new char[2];


                //Again getting the checksum of received string
                uint chkval = checksum(result1);

                chkval = chkval % 256;
                new_result2[0] = int2hex(chkval / 16);
                new_result2[1] = int2hex(chkval % 16);

                if ((new_result2[0] == result1[30] && new_result2[1] == result1[31])) //checksum validation
                {
                    float theta = float.Parse(idata1.Substring(1, 4)) / 1000;
                    float Epsilon = float.Parse(idata1.Substring(7, 4)) / 1000;

                    th_Field.Text = theta.ToString();
                    bige_Field.Text = Epsilon.ToString();


                }
                else
                {
                    MessageBox.Show("Checksum failed"); //if checksum char(s) validation fails, show fail
                }


                string feedback2 = "20000000000000000000000000000027";
                char[] fee = feedback2.ToCharArray();

                try
                {
                    Thread.Sleep(300);
                    COMport.Write(fee, 0, 32);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }

            if (idata1[0] == '6')
            {
                //Splitting string into two parts 30 bytes and 2 bytes for checksum
                char[] result1 = idata1.ToCharArray();


                // char[] rec2 = receive_data.Substring(30, 31).ToCharArray();
                char[] new_result2 = new char[2];


                //Again getting the checksum of received string
                uint chkval = checksum(result1);

                chkval = chkval % 256;
                new_result2[0] = int2hex(chkval / 16);
                new_result2[1] = int2hex(chkval % 16);

                if ((new_result2[0] == result1[30] && new_result2[1] == result1[31])) //checksum validation
                {
                    int timh = int.Parse(idata1.Substring(1, 10));
                    int param1 = int.Parse(idata1.Substring(11, 3));
                    int param2 = int.Parse(idata1.Substring(14, 3));
                    int param3 = int.Parse(idata1.Substring(17, 3));
                    int param4 = int.Parse(idata1.Substring(20, 3));

                    Health_Box.Text += (gettime(timh) + " - ");
                    Health_Box.Text += (param1.ToString("000") + ", ");
                    Health_Box.Text += (param2.ToString("000") + ", ");
                    Health_Box.Text += (param3.ToString("000") + ", ");
                    Health_Box.Text += (param4.ToString("000") + " \r\n");


                }
                else
                {
                    MessageBox.Show("Checksum failed"); //if checksum char(s) validation fails, show fail
                }


                string feedback2 = "20000000000000000000000000000027";
                char[] fee = feedback2.ToCharArray();

                try
                {
                    Thread.Sleep(300);
                    COMport.Write(fee, 0, 32);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }
        }

        private void connect_button_Click_1(object sender, EventArgs e)
        {
            string Port_Name = Get_Port.SelectedItem.ToString(); //get port name
            int Baud_Rate = Convert.ToInt32(Get_BR.SelectedItem); //get the baud rate

            if (openport(Port_Name, Baud_Rate) == true)
            {
                Get_Port.Enabled = false;
                Get_BR.Enabled = false;
                connect_button.Enabled = false;
                Log_Box.Text = ("Port opened");
            }
            else
            {
                MessageBox.Show("Port open error");
            }
        }

        public SerialPort COMport;

        public bool openport(string Port_Name, int Baud_Rate)
        {
            try
            {
                COMport = new SerialPort(Port_Name, Baud_Rate);
                COMport.DtrEnable = false;

                COMport.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);

                COMport.ReceivedBytesThreshold = 32;
                COMport.Open();
                Thread.Sleep(300);
                if (COMport.IsOpen == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        } // openport

        private void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            BeginInvoke((MethodInvoker)delegate { parsePacket(indata); });
        }

        private void th_Field_TextChanged(object sender, EventArgs e)
        {

        }
    } // Form 1


}
