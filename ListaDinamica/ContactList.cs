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
                str += temp + "\n\n";
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

        public bool RemoveByName(string target)
        {
            if (IsEmpty())
            {
                return false;
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
                return true;
            }

            Contact? prev = head;
            Contact? curr = head.GetNext();
            bool found = false;

            while (curr != null)
            {
                if (string.Equals(curr.GetName(), target))
                {
                    found = true;
                    if (curr == tail)
                    {
                        tail = prev;
                    }
                    prev.SetNext(curr.GetNext());
                    
                }
                prev = curr;
                curr = curr.GetNext();
            }
            return found;
        }

        public Contact? FindByName(string name)
        {
            Contact? curr = head;

            while (curr != null)
            {
                if (string.Equals(curr.GetName(), name))
                {
                    break;
                }
                curr = curr.GetNext();
            }

            return curr;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
