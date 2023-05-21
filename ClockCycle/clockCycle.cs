using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class clockCycle
    {
        public int ClockCounter { get; private set; } = 0;
        private static clockCycle instance = new clockCycle();
        private clockCycle()
        {

        }
        public static clockCycle GetInstance()
        {
            return instance;
        }
        public void Addone()
        {
            ClockCounter++;
        }
    }
}