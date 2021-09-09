using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    // 5Б Использование минимум 4 собственных классов; ()
    class Customer : Person
    {
        public string phoneNumber;
        public Customer(string name, string phoneNumber)
        {
            this.Name = name;
            this.phoneNumber = phoneNumber;
        }
        // 4Б Использование переопределений методов/ свойств; (методов)
        public override string GetName()
        {
            return "Заказчик: " + Name;
        }
    }

    // 1У Использование методов расширения;
    static class CustomerExtention
    {
        public static string GetSimpleName(this Customer source)
        {
            return source.Name;
        }
    }


}