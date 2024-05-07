using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDinamica
{
    internal class ContactList
    {
        Contact? head;
        Contact? tail;

        public ContactList()
        {
            this.head = null;
            this.tail = null;
        }

        public override string ToString()
        {
            Contact? temp = this.head;
            string str = "";

            while (temp != null)
            {
                str += temp + " ";
                temp = temp.GetNext();
            }
            return str;
        }

        public void Add(Contact contact)
        {
            if (IsEmpty())
            {
                this.head = contact;
                this.tail = contact;
                return;
            }

            Contact? prev = this.head;
            Contact? curr = this.head;
            int compare = string.Compare(contact.GetName(), head.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);
            if (compare <= 0)
            {
                Contact aux = head;
                head = contact;
                head.SetNext(aux);
            }
            else
            {
                do
                {
                    compare = string.Compare(contact.GetName(), curr.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);

                    if (compare > 0)
                    {
                        prev = curr;
                        curr = curr.GetNext();
                    }
                } while (curr != null && compare > 0);

                prev.SetNext(contact);
                contact.SetNext(curr);

                if (curr == null)
                {
                    this.tail = contact;
                }
            }
        }

        public Contact? Pop()
        {
            return tail;
        }

        public void RemoveByName(string target)
        {
            if (IsEmpty())
            {
                return;
            }

            if (string.Equals(head.GetName(), target))
            {
                if (head == tail)
                {
                    tail = head = null;
                }
                else
                {
                    head = head.GetNext();                
                }
                return;
            }

            Contact? prev = head;
            Contact? curr = head.GetNext();

            while (curr != null)
            {
                if (string.Equals(curr.GetName(), target))
                {
                    if (curr == tail)
                    {
                        tail = prev;
                    }
                    prev.SetNext(curr.GetNext());
                    
                }
                prev = curr;
                curr = curr.GetNext();
            }
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
