using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    // 2Б Использование абстрактных классов или членов класса;
    abstract class Delivery
    {
        public string address;
        public string type;
        public decimal Price { get; set; } = 0;
        public Delivery(string address)
        {
            this.address = address;
        }
        public Delivery() { }
    }

    // 1Б Использование наследования;
    class HomeDelivery : Delivery
    {
        public HomeDelivery(string address) : base(address)
        {
            base.Price = 101;
            base.type = "доставка домой";
        }
        public HomeDelivery() { }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery(string address) : base(address)
        {
            base.Price = 202;
            base.type = "доставка на точку выдачи";
        }
        public PickPointDelivery() { }
    }

    class ShopDelivery : Delivery
    {
        public ShopDelivery(string address) : base(address)
        {
            base.Price = 303;
            base.type = "доставка в магазин";
        }
        public ShopDelivery() { }
    }

}
