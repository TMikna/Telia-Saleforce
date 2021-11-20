using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Telia_Salesforece
{
    class Printer : IPrinter
    {
        public void PrintOrder(Order order, string filename) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(order, options);
            File.WriteAllText(filename, jsonString);
        }

        public void PrintOrderItem(OrderItem orderItem, string filename) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(orderItem, options);
            File.WriteAllText(filename, jsonString);
        }

        public void PrintOrderList(List<Order> ordersList, string filename) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(ordersList, options);
            File.WriteAllText(filename, jsonString);
        }
    }
}
