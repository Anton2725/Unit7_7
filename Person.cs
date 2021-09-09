using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    // 2Б Использование абстрактных классов или членов класса;
    // 5Б Использование минимум 4 собственных классов; (1)
    // 3П Корректное использование абстрактных классов(использовать их там, где это обусловлено параметрами системы);
    abstract class Person
    {
        // 8Б Использование свойств;
        protected string name;
        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual string GetName()
        {
            return "Человек " + Name;
        }
    }
}
