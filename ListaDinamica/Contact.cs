using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDinamica
{
    internal class Contact
    {
        string name;
        string phones; // Fazer uma lista dinamica (ou pilha, ou fila)
        string adrress; // Fazer um objeto
        string email;
        Contact? next;
        Contact? previous;

        public Contact(string name, string phone)
        {
            this.name = name;
            this.phones = phone;
            this.next = null;
        }

        public override string ToString()
        {
            return name.ToString();
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public Contact? GetNext()
        {
            return this.next;
        }

        public void SetNext(Contact next)
        {
            this.next = next;
        }
        public Contact? GetPevious()
        {
            return this.previous;
        }

        public void SetPevious(Contact previous)
        {
            this.previous = previous;
        }
    }
}
