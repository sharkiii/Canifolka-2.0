using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Canifolka_2._0
{
    public partial class Form1 : Form
    {
        Joystick joystick = new Joystick();
        Robot robotspeed = new Robot();
        Enotik enot;
        private Thread sendDataToRobot;
        public Form1()
        {
            InitializeComponent();
            if (joystick.IsConnected) checkBoxStick.Checked = true;
            else checkBoxStick.Checked = false;

            sendDataToRobot = new Thread(SendToRobot){IsBackground = true};
            joystick.IsConnectedChanged += new EventHandler(OnIsConnectChange);
        }
        private void OnIsConnectChange(object sender, EventArgs e)
        {
            Action action = () =>
            {
                if (joystick.IsConnected == true)
                {
                    checkBoxStick.Checked = true;
                }
                else checkBoxStick.Checked = false;
            };
            if (InvokeRequired)
            {
                Invoke(action);

            }
            else { action(); }
        }

        private void SendToRobot()
        {
            while (true)
            {
                robotspeed.SetSpeed();
                enot.TransmitData(0x01,robotspeed.SpeedRightSideForTransmittion,
                    robotspeed.SpeedLeftSideForTransmittion);
                Thread.Sleep(100);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enot = new Enotik();
            string[] myPorts;
            myPorts = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(myPorts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "ON")
            {
                enot.TransmitData(0x02, 0x00, 0x00);
                button1.Text = "OFF";
            }
            else
            {
                enot.TransmitData(0x03, 0x00, 0x00);
                button1.Text = "ON";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPortOK_Click(object sender, EventArgs e)
        {
            if (comboBoxPorts.SelectedItem != null)
            {
                enot.OpenPort(comboBoxPorts.SelectedItem.ToString());
                comboBoxPorts.Enabled = false;
            }
            else 
            {
                MessageBox.Show("Вы не выбрали порт","Ошибка",MessageBoxButtons.OK);
            }
        }
    }
}
