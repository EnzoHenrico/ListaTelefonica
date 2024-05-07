using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTelefoneDinamica
{
    internal class PhoneStack
    {
        PhoneNumber? top;
        int size;

        public PhoneStack()
        {
            this.top = null;
            this.size = 0;
        }

        public override string ToString()
        {
            string text = "";
            PhoneNumber? temp = this.top;

            while (temp != null)
            {
                text += temp.ToString();
                temp = temp.GetPrevious();
                
                if (temp != null)
                {
                    text += ", ";
                }
            }

            return text;
        }

        public void Push(PhoneNumber phone)
        {
            phone.SetPrevious(this.top);
            this.top = phone;
            size++;
        }

        public PhoneNumber? Pop()
        {
            if (IsEmpty())
            {
                return null;
            }

            PhoneNumber? removed = this.top;
            this.top = this.top?.GetPrevious();
            size--;
            return removed;
        }

        public int Size()
        {
            return this.size;
        }
        
        bool IsEmpty()
        {
            return this.top == null;
        }
    }
}
