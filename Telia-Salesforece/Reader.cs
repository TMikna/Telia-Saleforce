using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Telia_Salesforece
{
    class Reader : IReader
    {
        public Order ReadOrder(string filename) {
            string jsonString = File.ReadAllText(filename);
            Order order = JsonSerializer.Deserialize<Order>(jsonString);
            return order;
        }

        public OrderItem ReadOrderItem(string filename) {
            string jsonString = File.ReadAllText(filename);
            OrderItem orderItem = JsonSerializer.Deserialize<OrderItem>(jsonString);
            return orderItem;
        }

        // Read order item and add it to order
        public void ReadOrderItem(string filename, Order order) {
            string jsonString = File.ReadAllText(filename);
            OrderItem orderItem = JsonSerializer.Deserialize<OrderItem>(jsonString);
            order.OrderItems.Add(orderItem);
        }

        public List<Order> ReadOrderList(string filename) {
            string jsonString = File.ReadAllText(filename);
            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(jsonString);
            return orders;
        }
        // read order and add it to orders list
        public void ReadOrder(string filename, List<Order> orders) {
            string jsonString = File.ReadAllText(filename);
            Order order = JsonSerializer.Deserialize<Order>(jsonString);
            orders.Add(order);
        }
    }
}
