﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canifolka_2._0
{
    class Robot
    {
        private const int MaxSpeed = 100;
        private const int MinSpeed = -100;
        // Здесь хранится скорость приведенная от -100 до 100
        private int _speedRightSide;
        private int _speedLeftSide;

        // Скорость для передачи
        public byte SpeedRightSideForTransmittion { get; set; }
        public byte SpeedLeftSideForTransmittion { get; set; }

        private Joystick _joystick;
        public Robot()
        {
            _joystick = new Joystick();
        }

        private int Minimum(int a, int b)
        {
            if(a < b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        private int Maximum(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        // Приводим скорость к значения с джойстика
        private void SetSpeed()
        {
            _speedLeftSide = _joystick.LeftY + _joystick.RightX;
            _speedRightSide = _joystick.LeftY - _joystick.RightX;

            _speedLeftSide = Maximum(MinSpeed, Minimum(MaxSpeed, _speedLeftSide));
            _speedRightSide = Maximum(MinSpeed, Minimum(MaxSpeed, _speedRightSide));

            _joystick.newMaxRightTrigger = _speedRightSide;
            _joystick.newMaxLeftTrigger = _speedLeftSide;

            _speedRightSide = _speedRightSide - _joystick.RightTrigger;
            _speedLeftSide = _speedLeftSide - _joystick.LeftTrigger;

            if (!_joystick.IsConnected)
            {
                _speedLeftSide = 0;
                _speedRightSide = 0;
            }
        }

        // Приводим скорость к значениям для передачи
        public void SetSpeedForTransmittion()
        {
            SetSpeed();
            _speedLeftSide = _speedLeftSide + 100;
            _speedRightSide = _speedRightSide + 100;

            SpeedLeftSideForTransmittion =  Convert.ToByte(_speedLeftSide);
            SpeedRightSideForTransmittion = Convert.ToByte(_speedRightSide);
        }

    }
}
