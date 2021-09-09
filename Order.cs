using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    // 7Б Использование обобщений;
    class Order<TDelivery> where TDelivery : Delivery
    {
        //3Б Использование принципов инкапсуляции;

        // 1П Использование статических элементов или классов;
        // Для сквозной нумерации заказов.
        static public int lastNumber;
        // Номер заказа.
        protected int number;
        // Дата заказа.
        protected DateTime date;
        // Статус заказа.
        protected OrderStatus orderStatus;

        // 8Б Использование свойств;
        protected OrderStatus OrderStatus
        {
            get
            {
                return orderStatus;
            }
            set
            {
                switch (value)
                {
                    case OrderStatus.Доставка:
                        this.courierWork.StartWork();
                        orderStatus = value;
                        break;
                    case OrderStatus.Завершен:
                        this.courierWork.EndWork();
                        orderStatus = value;
                        break;
                    default:
                        orderStatus = value;
                        break;
                }

            }
        }
        // Заказчик.
        protected Customer customer;
        // Тип доставки.
        protected TDelivery delivery;
        // Курьер.
        protected Courier courier;
        // Работа курьера по доставке.
        protected CourierWork<TDelivery> courierWork;
        // Работа курьера по доставке.
        protected CourierExtraWork<TDelivery> courierExtraWork;
        // Строки с номенклатурой заказа.
        protected OrderTableRows orderTableRows;

        // 6Б Использование конструкторов классов с параметрами;
        public Order(TDelivery delivery, Courier courier, string nameCustomer, string phoneNumber)
        {
            this.delivery = delivery;
            this.customer = new Customer(nameCustomer, phoneNumber);
            lastNumber++;
            number = lastNumber;
            this.date = DateTime.Now;
            this.OrderStatus = OrderStatus.Открыт;

            this.courier = courier;

            // 9Б Использование композиции классов.
            this.courierWork = new CourierWork<TDelivery>(courier, delivery);
            this.courierExtraWork = new CourierExtraWork<TDelivery>("Вручить карту клиента", courier, delivery);
            this.orderTableRows = new OrderTableRows();
        }
        // Отобразить чек заказа.
        public void DisplayReceipt()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Номер заказа: {0}        Дата заказа: {1}", number, date);
            Console.WriteLine("{0} ({1})   Телефон: {2}", customer.GetName(), customer.GetSimpleName(), customer.phoneNumber);
            Console.WriteLine("Статус заказа: {0}", OrderStatus);
            Console.WriteLine("Тип доставки: {0}        Адрес: {1}", delivery.type, delivery.address);
            Console.WriteLine("--------------Состав заказа-----------");
            //foreach (var row in this.orderTableRows.data)
            for (int i = 0; i < 10; i++)
            {
                //if (row.name.Length != 0)
                if (orderTableRows[i] != null)
                {
                    Console.WriteLine("Наим.: {0}   | Кол : {1}   | Цена: {2}   | Сумма: {3}", orderTableRows[i].name, orderTableRows[i].quantity, orderTableRows[i].price, orderTableRows[i].GetSum());
                }
                else break;
            }
            Console.WriteLine();
            Console.WriteLine("Сумма заказа: {0}", orderTableRows.GetSum());
            Console.WriteLine("-----------Расчет доставки------------");
            Console.WriteLine("{0}", this.courier.GetName());
            var (startTime, endTime) = courierWork.GetStartEndTime();
            Console.WriteLine("Начало: {0}         Окончание: {1}", startTime, endTime);
            Console.WriteLine();
            Console.WriteLine("Стоимость доставки: {0}", courierWork.CostWork());
            Console.WriteLine("Доп. работа: {0}", courierExtraWork.GetExtraWork());
            Console.WriteLine("----------------ИТОГО-----------------");
            decimal sum = orderTableRows.GetSum() + courierWork.CostWork();
            Console.WriteLine("Сумма итого: {0}", sum);
        }
        // Добавить строку номенклатуры в заказ.
        public void AddRow(int index, string name, decimal quantity, decimal price)
        {
            orderTableRows[index] = new OrderTableRow(name, quantity, price);
        }
        // Установить статус заказа.
        public void SetStatus(OrderStatus orderStatus)
        {
            this.OrderStatus = orderStatus;
        }
    }




    enum OrderStatus
    {
        Открыт,
        Комплектация,
        Доставка,
        Завершен,
        Отменен
    }

}
