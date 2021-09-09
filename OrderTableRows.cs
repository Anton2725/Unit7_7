using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7_7
{
    // 5Б Использование минимум 4 собственных классов; (4)
    class OrderTableRows
    {
        protected OrderTableRow[] data;
        public OrderTableRows()
        {
            data = new OrderTableRow[10];
        }

        // 4У Использование индексаторов
        public OrderTableRow this[int index]
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
        public decimal GetSum()
        {
            decimal sum = 0;
            foreach (var row in data)
            {
                if (row != null)
                {
                    //sum += row.GetSum();

                    // 5У Использование перегруженных операторов.
                    sum += +row;
                }
            }
            //decimal = data[0] + data[1];

            return sum;
        }
    }

    class OrderTableRow
    {
        public string name;
        public decimal quantity;
        public decimal price;

        public OrderTableRow(string name, decimal quantity, decimal price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }

        public decimal GetSum()
        {
            decimal sum = this.quantity * this.price;
            return sum;
        }

        // 5У Использование перегруженных операторов.
        public static decimal operator +(OrderTableRow row)
        {
            return row.GetSum();
        }
    }
}
