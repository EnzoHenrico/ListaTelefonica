using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTelefoneDinamica
{
    internal class Address
    {
        string street;
        string city;
        string state;
        string zip;

        public Address(string street, string city, string state, string zip)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        public override string ToString()
        {
            return $"{street}, {city} - {state} {zip}";
        }
    }
}
