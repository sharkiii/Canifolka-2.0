using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canifolka_2._0
{
    class Robot
    {
        public const int MaxSpeed = 100;
        public const int MinSpeed = -100;

        // Скорость для передачи
        public byte SpeedRightSideForTransmittion { get; set; }
        public byte SpeedLeftSideForTransmittion { get; set; }

        public Robot()
        {
        }

    }
}
