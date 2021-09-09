using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    class Courier : Person
    {
        // 4Б Использование переопределений методов/ свойств; (свойств)
        // 5Б Использование минимум 4 собственных классов; (2)
        public override string Name
        {
            // 5П Использование свойств с логикой в get и/или set блоках.
            get
            {
                return "*** " + this.name;
            }
            set
            {
                if (value.Length == 0) name = "Анонимный курьер";
                else name = value;
            }
        }
        public Delivery delivery;
        private int workHours;
        public Courier(string name, Delivery delivery)
        {
            this.Name = name;
            this.delivery = delivery;
        }
        // 4Б Использование переопределений методов/ свойств; (методов)
        public override string GetName()
        {
            return "Курьер: " + Name;
        }
        public void AddWorkHours(int workHours)
        {
            this.workHours += workHours;
        }
        public int GetWorkHours()
        {
            return workHours;
        }
        static public void DisplayAllCouriersWorkHours(Courier[] couriers)
        {
            Console.WriteLine();
            Console.WriteLine("*****************ОТРАБОТАННЫЕ ЧАСЫ КУРЬЕРОВ*******************");
            for (int i = 0; i < couriers.Length; i++)
            {
                Console.WriteLine("{0}   время, ч: {1}", couriers[i].GetName(), couriers[i].GetWorkHours());
            }
            Console.WriteLine("**************************************************************");
        }


    }

}
