using System;

namespace Unit7_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Для упрощения проверки задания, процетирую требования к нему из Юнита 7.7:
            /*Базовый уровень:
            ---------------
            1Б Использование наследования;
            2Б Использование абстрактных классов или членов класса;
            3Б Использование принципов инкапсуляции;
            4Б Использование переопределений методов/ свойств;
            5Б Использование минимум 4 собственных классов;
            6Б Использование конструкторов классов с параметрами;
            7Б Использование обобщений;
            8Б Использование свойств;
            9Б Использование композиции классов.

            Продвинутый уровень:
            -------------------
            1П Использование статических элементов или классов;
            2П Использование обобщенных методов;
            3П Корректное использование абстрактных классов(использовать их там, где это обусловлено параметрами системы);
            4П Корректное использование модификаторов элементов класса(чтобы важные поля не были доступны для полного контроля извне, использование protected);
            5П Использование свойств с логикой в get и/или set блоках.

            Усложненный уровень:
            -------------------
            1У Использование методов расширения;
            2У Использование наследования обобщений;
            3У Использование агрегации классов;
            4У Использование индексаторов;
            5У Использование перегруженных операторов.*/

            // Пронумеровал требования. Далее буду подставлять строку из требований, там где они реализованы,
            // но не во всех случаях где встречается в коде, а только в нескольких местах, чтобы обозначить факт выполнения.
            // Так же этот список удобно "крыжить".
            // Во многих местах функциональность, логика, реализация объектов, методов, полей и свойств надуманы и притянуты за уши,
            // прошу не бить за это ногами сильно. Это сделано только для демонстрации урока.


            // Заполним сразу штук 5 доставщиков.
            // Предположим они заполняются из базы данных.
            // Предположим, что за каждым курьером закреплен определенный тип доставки.
            Courier[] couriers = new Courier[5];
            couriers[0] = new Courier("Вася", new HomeDelivery());
            couriers[1] = new Courier("Петя", new PickPointDelivery());
            couriers[2] = new Courier("Валентин", new ShopDelivery());
            couriers[3] = new Courier("Андрей", new HomeDelivery());
            couriers[4] = new Courier("Маша", new PickPointDelivery());

            // Создадим накопитель заказов.
            AllOrders allOrders = new AllOrders();

            // По звонку заказчика определили адрес доставки и тип доставки.
            HomeDelivery deliveryHome = new HomeDelivery("ул. Блюхера, д. 5, кв. 33");

            // По типу доставки получили первого попавшегося подходящего курьера.
            Courier courierHome = GetCourier(couriers, deliveryHome);

            // Оформляем заказ.
            Order<Delivery> orderHome = allOrders.AddOrder(0, deliveryHome, courierHome, "Антон", "+7922123456");

            // Наполняем состав заказа.
            orderHome.SetStatus(OrderStatus.Комплектация);
            orderHome.AddRow(0, "Пельмени, 100 гр.", 2, 200);
            orderHome.AddRow(1, "Сметана, 50 гр.", 1, 70);
            orderHome.AddRow(2, "Вилка, 1 шт.", 1, 15);

            // Тут начинается отсчет времени затраченного на доставку.
            orderHome.SetStatus(OrderStatus.Доставка);

            // Например получили ответ от курьера о доставке на место.
            // Таким образом завершаем отсчет потраченного времени на доставку.
            // Для простоты это всегда +2 часа ко времени старта.
            orderHome.SetStatus(OrderStatus.Завершен);

            // Можем напечатать чек, а можем потом из накопителя заказов сразу распечатать все чеки.
            //orderHome.DisplayReceipt();


            // Создадим для примера еще один заказ.
            PickPointDelivery deliveryPickPoint = new PickPointDelivery("ул. Комсомольская, д. 20, магазин 'Пятерочка'");
            Courier courierPickPoint = GetCourier(couriers, deliveryPickPoint);
            Order<Delivery> orderPickPoint = allOrders.AddOrder(1, deliveryPickPoint, courierPickPoint, "Вальдемар", "+7901666321");

            orderPickPoint.SetStatus(OrderStatus.Комплектация);
            orderPickPoint.AddRow(0, "Перепелка под соусом мишель, 250 гр.", 1, 1300);
            orderPickPoint.AddRow(1, "Салат Цезарь, 150 гр.", 1, 800);
            orderPickPoint.SetStatus(OrderStatus.Доставка);
            orderPickPoint.SetStatus(OrderStatus.Завершен);

            // Выведем чеки всех заказов.
            allOrders.DisplayAllOrders();

            // Выведем сколько времени работали курьеры.
            Courier.DisplayAllCouriersWorkHours(couriers);

            Console.ReadKey();
        }

        static public Courier GetCourier<TDelivery>(Courier[] couriers, TDelivery delivery) where TDelivery : Delivery
        {
            foreach (var courier in couriers)
            {
                if (courier.delivery.GetType() == delivery.GetType()) return courier;
            }
            return null;
        }

    }
}
