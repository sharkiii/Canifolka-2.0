using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Threading;

namespace Canifolka_2._0
{
    class Joystick
    {
        #region Constants
        // Мертвая зона левого стика
        private const int DeathZoneLeftStickTop = 4000;     //Что-то тупит верхняя граница
        private const int DeathZoneLeftStickBottom = -1000;
        private const int DeathZoneLeftStickRight = 3000;
        private const int DeathZoneLeftStickLeft = -1600;

        // Мертвая зона правого стика
        private const int DeathZoneRightStickTop = 4000;  
        private const int DeathZoneRightStickBottom = 0;
        private const int DeathZoneRightStickRight = 0;
        private const int DeathZoneRightStickLeft = -3500;

        // Значения с джойстика
        private  const int MaxStickValue = 32767;
        private  const int MinStickValue = -32768;

        // Диапазон джойстика
        private  const int TopStickLimit = 100;
        private  const int BottomStickLimit = -100;
        #endregion

        #region PropertiesInt
        public int LeftY { get; set; }
        public int LeftX { get; set; }
        public int RightY { get; set; }
        public int RightX { get; set; }
        public int LeftTrigger { get; set; }
        public int RightTrigger { get; set; }
        #endregion

        #region PropertiesBool
        public bool ButtonA
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            }
            set 
            { 
                
            }
        }
        public bool ButtonY 
        { 
            get 
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            }
            set
            { 
            
            }
        }
        public bool ButtonX 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            }
            set
            { 
            }
        }
        public bool ButtonB 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            }
            set
            { 
            }
        }
        public bool LeftThumb 
        { 
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
            }
        }
        public bool RightThumb {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            }
            set 
            { 
            
            }
        }
        public bool ButtonStart 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
            }
        }
        public bool ButtonBack 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
            } 
        }
        public bool DPadUp 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            }
        }
        public bool DPadDown 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            }
        }
        public bool DPadRight 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
            }
        }

        public bool DPadLeft 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            }
        }
        public bool RightShoulder 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
            }
        }
        public bool LeftShoulder 
        {
            get
            {
                return _gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            } 
        }
        public bool IsConnected 
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if (value == _isConnected) return;
                _isConnected = value;
                if (IsConnectedChanged != null) IsConnectedChanged(this, EventArgs.Empty);
            }
        }
        #endregion

        public event EventHandler IsConnectedChanged;
        private bool _isConnected;
        private Controller _controller;
        private Gamepad _gamepad;

        // Конструктор, запуск потока для проверки и создание объектов джойстика
        public Joystick()
        {
           _controller = new Controller(UserIndex.One);
           Thread ConnectionThread = new Thread(CheckConnection){IsBackground = true};
           ConnectionThread.Start();
        }

        // Метод, который вызывается в потоке и служит для обработки джойстика и 
        // проверки его подключения
        private void CheckConnection()
        { 
            while(true)
            {
                IsConnected = _controller.IsConnected;
                if (_isConnected) PollJoystick();
                Thread.Sleep(50);
            }

        }
        // Функция аналогичная ардуиновской
        private int Map(int data, int inMin, int inMax, int outMin, int outMax)
        {
            return (data - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        // Обработка джойстика
        private void PollJoystick()
        {
            _gamepad = _controller.GetState().Gamepad;

            //Левый джойстик обработка
            if (_gamepad.LeftThumbY > DeathZoneLeftStickTop)
            {
                LeftY = Map(_gamepad.LeftThumbY, DeathZoneLeftStickTop, MaxStickValue,
                    0, TopStickLimit);
            }
            else
            {
                if (_gamepad.LeftThumbY < DeathZoneLeftStickBottom)
                {
                    LeftY = Map(_gamepad.LeftThumbY, DeathZoneLeftStickBottom,
                        MinStickValue, 0, BottomStickLimit);
                }
                else LeftY = 0;
                
            }

            if (_gamepad.LeftThumbX > DeathZoneLeftStickRight)
            {
                LeftX = Map(_gamepad.LeftThumbX, DeathZoneRightStickRight, MaxStickValue,
                    0, TopStickLimit);
            }
            else 
            {
                if (_gamepad.LeftThumbX < DeathZoneLeftStickLeft)
                {
                    LeftX = Map(_gamepad.LeftThumbX, DeathZoneRightStickLeft, MinStickValue,
                        0, BottomStickLimit);
                }
                else LeftX = 0;
            }

            // Правый джойстик обработка
            if (_gamepad.RightThumbX > DeathZoneRightStickRight)
            {
                RightX = Map(_gamepad.RightThumbX, DeathZoneRightStickRight,
                    MaxStickValue, 0, TopStickLimit);
            }
            else
            {
                if (_gamepad.RightThumbX < DeathZoneRightStickLeft)
                {
                    RightX = Map(_gamepad.RightThumbX, DeathZoneRightStickLeft,
                        MinStickValue, 0, BottomStickLimit);
                }
                else RightX = 0;
            }

            if (_gamepad.RightThumbY > DeathZoneRightStickTop)
            {
                RightY = Map(_gamepad.RightThumbY, DeathZoneRightStickTop, MaxStickValue,
                    0, TopStickLimit);
            }
            else
            {
                if (_gamepad.RightThumbX < DeathZoneRightStickBottom)
                {
                    RightY = Map(_gamepad.RightThumbY, DeathZoneRightStickBottom, MinStickValue,
                        0, BottomStickLimit);
                }
                else RightY = 0;
            }



        }

        private void PollLeftAndRightTriggers()
        { 
            //Обработка притармаживания RT и LT
        
        }
    }
}
