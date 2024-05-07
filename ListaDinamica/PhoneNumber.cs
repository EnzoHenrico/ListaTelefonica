using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTelefoneDinamica
{
    internal class PhoneNumber
    {
        string number;
        PhoneNumber? previous;

        public PhoneNumber(string number)
        {
            this.number = number;
            this.previous = null;
        }

        public void SetPrevious(PhoneNumber? previous)
        {
            this.previous = previous;
        }
        public PhoneNumber? GetPrevious()
        {
            return this.previous;
        }

        public string GetNumber()
        {
            return this.number;
        }

        public override string ToString()
        {
            return this.number;
        }
    }
}
