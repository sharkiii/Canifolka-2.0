using System;
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

        // Скорость для передачи
        public byte SpeedRightSideForTransmittion { get; set; }
        public byte SpeedLeftSideForTransmittion { get; set; }

        private Joystick _joystick;
        public Robot()
        {
            _joystick = new Joystick();
        }

       
        // Приводим скорость к значения с джойстика
        public void SetSpeed()
        {
            // speedLeftSide = _joystick.LeftY + _joystick.RightX;
            // speedRightSide = _joystick.LeftY - _joystick.RightX;

            speedLeftSide = Math.Max(MinSpeed, Math.Min(MaxSpeed, speedLeftSide));
            speedRightSide = Math.Max(MinSpeed, Math.Min(MaxSpeed, speedRightSide));

            _joystick.NewMaxRightTrigger = speedRightSide;
            _joystick.NewMaxLeftTrigger = speedLeftSide;

            speedRightSide = speedRightSide - _joystick.RightTrigger;
            speedLeftSide = speedLeftSide - _joystick.LeftTrigger;

            if (!_joystick.IsConnected)
            {
                speedLeftSide = 0;
                speedRightSide = 0;
            }

            SpeedLeftSideForTransmittion = Convert.ToByte(speedLeftSide);
            SpeedRightSideForTransmittion = Convert.ToByte(speedRightSide);

            SpeedLeftSideForTransmittion += 100;
            SpeedRightSideForTransmittion += 100;

        }

    }
}
