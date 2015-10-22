using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canifolka_2._0
{
    class Enotik
    {
        private Robot _robotSpeed;
        private byte[] buffer;
        private const byte ID = 0xFF;
        public Enotik()
        {
            _robotSpeed = new Robot();
        }

        public static byte CRC8(byte[] data, int len)
        {
            UInt32 crc = 0x000000FF;

            for (int i = 0; i < len; ++i)
            {
                crc ^= data[i];

                for (int k = 0; k < 8; ++k)
                {
                    if (Convert.ToBoolean(crc & 0x00000080))
                        crc = (crc << 1) ^ 0x00000031;
                    else
                        crc = crc << 1;

                    crc &= 0x000000FF;
                }
            }

            return Convert.ToByte(crc);
        }

        public void transmitData(byte[] buffer)
        { 
            
        }

        private void makeBuffer(byte oppset, byte one, byte two)
        {
            // Пример: ID,OPPSET,ONE,TWO,CRC8
            byte[] toCRC8 = { ID, oppset, one, two };
            byte [] buf = {ID ,oppset, one, two, CRC8(toCRC8, toCRC8.Length)};
            buffer = buf; 
            

        }

    }
}
