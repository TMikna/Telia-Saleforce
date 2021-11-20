using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    public class Order
    {
        int itemCount;        
        public int ItemCount { get => itemCount; set => itemCount = value; }

        private List<OrderItem> orderItems = new List<OrderItem>();
        public List<OrderItem> OrderItems { get => orderItems; set => orderItems = value; }

        public Order() {
        }
    }
}
