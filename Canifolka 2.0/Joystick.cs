using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        //Диапазон LeftTrigger и RightTrigger
        private const int MinTriggerValue = 0;
        private const int MaxTriggerValue = 255;
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
                if (ButtonAStateChanged != null && value && !_prevValButtonA) ButtonAStateChanged(this, EventArgs.Empty);
                _prevValButtonA = value;
            }
        }

        public bool ButtonY { get; set; }
        public bool ButtonX { get; set; }

        public bool ButtonB { get; set; }

        public bool LeftThumb { get; set; }

        public bool RightThumb { get; set; }

        public bool ButtonStart { 
            get { return _gamepad.Buttons.HasFlag(GamepadButtonFlags.Start); }
            set
            {
                if (ButtonStartStateChanged != null && value && !_prevValButtonStart) ButtonStartStateChanged(this, EventArgs.Empty);
                _prevValButtonStart = value;
            }
        }

        public bool ButtonBack { get; set; }

        public bool DPadUp { get; set; }

        public bool DPadDown { get; set; }

        public bool DPadRight { get; set; }

        public bool DPadLeft { get; set; }

        public bool RightShoulder { get; set; }

        public bool LeftShoulder { get; set; }

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

        public int NewMaxRightTrigger = 0;
        public int NewMaxLeftTrigger = 0;
        public event EventHandler IsConnectedChanged;
        public event EventHandler ButtonAStateChanged;
        public event EventHandler ButtonStartStateChanged;
        private bool _isConnected;
        private readonly Controller _controller;
        private Gamepad _gamepad;
        private bool _prevValButtonA = false;
        private bool _prevValButtonStart = false;

        // Конструктор, запуск потока для проверки и создание объектов джойстика
        public Joystick()
        {
           _controller = new Controller(UserIndex.One);
        }

        // Метод, который вызывается в потоке и служит для обработки джойстика и 
        // проверки его подключения
        public void CheckConnectionAndPolling()
        { 
            IsConnected = _controller.IsConnected;
            if (_isConnected)
            {
                _gamepad = _controller.GetState().Gamepad;
                PollJoystick();
                PollButtons();
                PollLeftAndRightTriggers(NewMaxRightTrigger, NewMaxLeftTrigger);
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

        private void PollLeftAndRightTriggers(int newMaxRight, int newMaxLeft)
        {
            RightTrigger = Map(_gamepad.RightTrigger, MinTriggerValue, MaxTriggerValue,
                MinTriggerValue, newMaxRight);

            LeftTrigger = Map(_gamepad.LeftTrigger, MinTriggerValue, MaxTriggerValue,
                MinTriggerValue, newMaxLeft);
        }

        private void PollButtons()
        {
            ButtonA = _gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            ButtonB = _gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            ButtonX = _gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            ButtonY = _gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            ButtonStart = _gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
            ButtonBack = _gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
            LeftShoulder = _gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            RightShoulder = _gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
            LeftThumb = _gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
            RightThumb = _gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
            DPadUp = _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            DPadDown = _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            DPadRight = _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
            DPadLeft = _gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
        }
    }
}
