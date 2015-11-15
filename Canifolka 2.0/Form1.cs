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
        #region ModeStateBooleans

        private bool _driveLine = false;
         

        #endregion

        readonly Joystick _joystick = new Joystick();
        readonly Robot _robot = new Robot();
        Enotik enot;
        private const byte DriveOppcode = 0x01;
        private const byte CameraOppcode = 0x02;
        private const byte LineSensorOppcode = 0x03;
        private const byte NullByte = 0x00;
        private const byte ID = 0x01;
        private const int BaudRate = 9600;

        private byte _cameraState = 0x00;
        private byte _lineSensorState = 0x00;
        private int _speedRightSide;
        private int _speedLeftSide;
        private const int ConstForTransmittion = 100;
        private Thread _pollJoystick;
        public Form1()
        {
            InitializeComponent();
            if (_joystick.IsConnected) checkBoxStick.Checked = true;
            else checkBoxStick.Checked = false;
            enot = new Enotik(0x01, BaudRate);
            _pollJoystick = new Thread(CheckStickConnectionAndPollIt){IsBackground = true};
            _pollJoystick.Start();
            _joystick.IsConnectedChanged += new EventHandler(OnIsConnectChange);
            _joystick.ButtonAStateChanged += new EventHandler(OnAPressed);
            _joystick.ButtonStartStateChanged += new EventHandler(OnStartPressed);
            enot.MessageReceived += new EventHandler<byte[]>(OnMessageReceived);

        }

        private void OnMessageReceived(object sender, byte[] e)
        {
            // Здесь уже делаем проверку по oppcode и так далее
        }

        private void OnStartPressed(object sender, EventArgs e)
        {
            if (_cameraState == 0x00) _cameraState = 0x01;
            else _cameraState = 0x00;
        }


        private void OnAPressed(object sender, EventArgs e)
        {
            if (_lineSensorState == 0x00) _lineSensorState = 0x01;
            else _lineSensorState = 0x00;
        }

        private void OnIsConnectChange(object sender, EventArgs e)
        {
            Action action = () =>
            {
                if (_joystick.IsConnected == true)
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

        private void SetSpeed()
        {
            _speedLeftSide = _joystick.LeftY + _joystick.RightX;
            _speedRightSide = _joystick.LeftY - _joystick.RightX;
            
            _speedLeftSide = Math.Max(Robot.MinSpeed, Math.Min(Robot.MaxSpeed, _speedLeftSide));
            _speedRightSide = Math.Max(Robot.MinSpeed, Math.Min(Robot.MaxSpeed, _speedRightSide));

            _joystick.NewMaxRightTrigger = _speedRightSide;
            _joystick.NewMaxLeftTrigger = _speedLeftSide;

            _speedRightSide = _speedRightSide - _joystick.RightTrigger;
            _speedLeftSide = _speedLeftSide - _joystick.LeftTrigger;

            if (!_joystick.IsConnected)
            {
                _speedLeftSide = 0;
                _speedRightSide = 0;
            }

            _robot.SpeedLeftSideForTransmittion = Convert.ToByte(_speedLeftSide + ConstForTransmittion);
            _robot.SpeedRightSideForTransmittion = Convert.ToByte(_speedRightSide + ConstForTransmittion);

        }

        private void CheckStickConnectionAndPollIt()
        {
            while (true)
            {
                _joystick.CheckConnectionAndPolling();
                SetSpeed();
                enot.TransmitData(DriveOppcode, _robot.SpeedRightSideForTransmittion, _robot.SpeedLeftSideForTransmittion);
                enot.TransmitData(CameraOppcode, _cameraState, NullByte);
                enot.TransmitData(LineSensorOppcode, _lineSensorState, NullByte);
                Thread.Sleep(100);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            if (comboBoxPorts.Enabled == true)
            {
                if (comboBoxPorts.SelectedItem != null)
                {
                    enot.OpenPort(comboBoxPorts.SelectedItem.ToString());
                    comboBoxPorts.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Вы не выбрали порт", "Ошибка", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (MessageBox.Show("Вы уверены что вы хотите поменять COM-порт?", "Предупреждение",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    comboBoxPorts.Enabled = true;
                }
            }
        }
    }
}
