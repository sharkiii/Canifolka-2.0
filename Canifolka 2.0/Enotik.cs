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


        public void transmitData(byte[] buffer)
        { 
            
        }

        private void makeBuffer(byte oppset, byte one, byte two)
        {
            // Пример: ID,OPPSET,ONE,TWO,CRC8
            byte[] toCRC8 = { ID, oppset, one, two };
            //byte [] buf = {ID ,oppset, one, two, CRC8(toCRC8)};
           // buffer = buf; 
            

        }

    }
}
