using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    interface IReader
    {
        List<Order> ReadOrderList(string filename);
        Order ReadOrder(string filename);
        void ReadOrder(string filename, List<Order> orders);
        OrderItem ReadOrderItem(string filename);
        void ReadOrderItem(string filename, Order order);
    }
}
