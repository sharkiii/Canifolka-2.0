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
        public Form1()
        {
            InitializeComponent();
            if (joystick.IsConnected) label1.Text = "Джойстик подключен";
            else label1.Text = "Джойстик отключен";
            joystick.IsConnectedChanged += new EventHandler(OnIsConnectChange);
            Thread dataFromJoystick = new Thread(JoyState) { IsBackground = true};
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

        }

        private void JoyState()
        {
            while (true)
            {
                Action action = () =>
                {
                    label_leftY.Text = joystick.LeftY.ToString();
                    labelRightX.Text = joystick.RightX.ToString();
                    Thread.Sleep(50);
                };
                if (InvokeRequired)
                {
                    Invoke(action);

                }
                else { action(); }
            }
        }
    }
}
