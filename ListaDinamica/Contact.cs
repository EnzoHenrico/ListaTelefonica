using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ListaDeTelefoneDinamica;

namespace ListaDinamica
{
    internal class Contact
    {
        string name;
        string? email;
        PhoneStack? phones;
        Address? address;
        Contact? next;

        public Contact(string name, string phone)
        {
            this.name = name;
            this.phones = new();
            this.phones.Push(new(phone));
            this.next = null;
        }

        public override string ToString()
        {
            return $"Nome: {name}\nTelefone: {phones}\nE-mail: {email}\nEndereço: {address}";
        }

        public void PushNewPhone(string phone)
        {
            this.phones.Push(new(phone));
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string? GetEmail()
        {
            return this.email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public Address? GetAddress()
        {
            return this.address;
        }

        public void SetAddress(Address? address)
        {
            this.address = this.address;
        }

        public Contact? GetNext()
        {
            return this.next;
        }

        public void SetNext(Contact next)
        {
            this.next = next;
        }
    }
}
