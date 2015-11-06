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
        Thread dataFromJoystick;
        public Form1()
        {
            InitializeComponent();
            if (joystick.IsConnected) label1.Text = "Джойстик подключен";
            else label1.Text = "Джойстик отключен";
            joystick.IsConnectedChanged += new EventHandler(OnIsConnectChange);
            dataFromJoystick = new Thread(JoyState) { IsBackground = true};
            dataFromJoystick.Start();
        }
        private void OnIsConnectChange(object sender, EventArgs e)
        {
            Action action = () =>
            {
                if (joystick.IsConnected == true)
                {
                    label1.Text = "Джойстик подключен";
                }
                else label1.Text = "Джойстик отключен";
            };
            if (InvokeRequired)
            {
                Invoke(action);

            }
            else { action(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enot = new Enotik();
            string[] myPorts;
            myPorts = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(myPorts);
        }

        private void JoyState()
        {
            Action action = () =>
            {
                robotspeed.SetSpeedForTransmittion();
                label_leftY.Text = robotspeed.SpeedLeftSideForTransmittion.ToString();
                labelRightX.Text = robotspeed.SpeedRightSideForTransmittion.ToString();                
            };

            while (true)
            {
                
                if (InvokeRequired)
                {
                   Invoke(action);
                }
                else { action(); }
                Thread.Sleep(100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enot.transmitData(0x02, 0x00, 0x00);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           dataFromJoystick.Abort();
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPortOK_Click(object sender, EventArgs e)
        {
            if (comboBoxPorts.SelectedItem != null)
            {
                enot.initComPortAndThread(comboBoxPorts.SelectedItem.ToString());
                comboBoxPorts.Enabled = false;
            }
            else 
            {
                MessageBox.Show("Вы не выбрали порт","Ошибка",MessageBoxButtons.OK);
            }
        }
    }
}
