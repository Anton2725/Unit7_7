using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    // 7Б Использование обобщений;
    class CourierWork<TDelivery> where TDelivery : Delivery
    {
        // 4П Корректное использование модификаторов элементов класса(чтобы важные поля не были доступны для полного контроля извне, использование protected);
        // Тип заказа.
        private readonly TDelivery delivery;
        // Курьер.
        private readonly Courier courier;
        // Время начала доставки.
        private DateTime startTime;
        // Время окончания доставки.
        private DateTime endTime;
        // Стоимость доставки.
        private decimal costOfWork;

        // 6Б Использование конструкторов классов с параметрами;
        public CourierWork(Courier courier, TDelivery delivery)
        {
            // 3У Использование агрегации классов;
            this.courier = courier;
            this.delivery = delivery;
        }
        public void StartWork()
        {
            startTime = DateTime.Now;
        }
        public void EndWork()
        {
            // Пусть для простоты у всех время на доставку ушло 2 часа.
            endTime = startTime.AddHours(2);

            // Подсчитаем время работы курьера.
            var diff = this.endTime - this.startTime;
            courier.AddWorkHours((int)diff.TotalHours);
        }
        public decimal CostWork()
        {
            var diff = this.endTime - this.startTime;
            this.costOfWork = ((decimal)diff.TotalHours * this.delivery.Price);

            return this.costOfWork;
        }
        public (DateTime startTime, DateTime endTime) GetStartEndTime()
        {
            return (this.startTime, this.endTime);
        }
    }

    // 2У Использование наследования обобщений;
    class CourierExtraWork<TDelivery> : CourierWork<TDelivery> where TDelivery : Delivery
    {
        protected string Name { get; set; } = "";
        public CourierExtraWork(string name, Courier courier, TDelivery delivery) : base(courier, delivery)
        {
            Name = name;
        }
        public string GetExtraWork()
        {
            return Name;
        }
    }
}
