using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    public class Order
    {
        int itemCount;
        DateTime date;
        public List<OrderItem> OrderItems = new List<OrderItem>();

        public Order() {
        }

        public int ItemCount { get => itemCount; set => itemCount = value; }
    }

}
