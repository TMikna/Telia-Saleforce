using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    interface IPrinter
    {
        void PrintOrder(Order order, string filename);
        void PrintOrderItem(OrderItem orderItem, string filename);
        void PrintOrderList(List<Order> orderList, string filename);
    }
}
