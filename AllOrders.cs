using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    class AllOrders
    {
        protected Order<Delivery>[] data;

        // 4У Использование индексаторов
        public Order<Delivery> this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public AllOrders()
        {
            this.data = new Order<Delivery>[10];
        }

        // 2П Использование обобщенных методов;
        public Order<Delivery> AddOrder<TDelivery>(int index, TDelivery delivery, Courier courier, string customerName, string phoneNumber) where TDelivery : Delivery
        {
            Order<Delivery> order = new Order<Delivery>(delivery, courier, customerName, phoneNumber);
            data[index] = order;
            return order;
        }
        public void DisplayAllOrders()
        {
            Console.WriteLine("*******************ВСЕ ЗАКАЗЫ*********************************");
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {

                    data[i].DisplayReceipt();
                }
                else break;
            }
            Console.WriteLine("**************************************************************");
        }
    }
}
