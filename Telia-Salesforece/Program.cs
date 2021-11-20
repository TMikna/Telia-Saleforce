using System;
using System.Collections.Generic;


namespace Telia_Salesforece
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Program started!\n");

            Demo demo = new Demo();
            demo.Test();
            demo.Test200();
        }

        class Demo
        {

            public void Test() {
                Console.WriteLine("Test() method started");

                // 1st create list of orders
                List<Order> orders = new List<Order>();
                // 2nd create order
                var order = new Order();
                // 3rd create order 
                var orderItem = new OrderItem();
                // add order Item to an order
                order.OrderItems.Add(orderItem);
                // add some more order items to the order
                order.OrderItems.Add(new OrderItem());
                order.OrderItems.Add(new OrderItem());
                // add order to order list
                orders.Add(order);

                // create some more orders and add them to orders list
                for (int i = 0; i < 20; i++)
                {
                    int j = 5;
                    var _order = new Order();

                    // for each order create and add some order items
                    while (j > 0)
                    {
                        _order.OrderItems.Add(new OrderItem());
                        j--;
                    }
                    orders.Add(_order);
                }

                // Print unhandled OrderItem, Order and Orders list
                IPrinter printer = new Printer();
                printer.PrintOrderItem(orderItem, "orderItem.json");
                printer.PrintOrder(order, "order.json");
                printer.PrintOrderList(orders, "orders.json");

                //Manage orders in order list
                AssetManagementTask amt = new AssetManagementTask();
                amt.executeBatch(orders);
                //print managed orders
                printer.PrintOrderList(orders, "managedOrders1.json");
                Console.WriteLine("Orders created, added to a list, managed and printed to a file");


                // create and add some more orders to orders list list
                for (int i = 0; i < 20; i++)
                {
                    int j = 5;
                    var _order = new Order();

                    while (j > 0)
                    {
                        _order.OrderItems.Add(new OrderItem());
                        j--;
                    }
                    orders.Add(_order);
                }

                //manage orders again
                amt.executeBatch(orders);
                // print updated and managed list
                printer.PrintOrderList(orders, "managedOrders2.json");
                Console.WriteLine("List updated with new orders, managed and printed to a file");


                // Read and write order to show it can be read and printed without affecting the order
                IReader reader = new Reader();
                var deserialisedOrder = reader.ReadOrder("order.json");
                printer.PrintOrder(deserialisedOrder, "ReserialisedOrder.json");

            }

            // test program with 200 orders having 20 order item each
            public void Test200() {
                Console.WriteLine("Test200() method started");

                List<Order> orders = new List<Order>();
                for (int i = 0; i < 200; i++)
                {
                    Order order = new Order();
                    for (int j = 0; j < 20; j++)
                        order.OrderItems.Add(new OrderItem());
                    orders.Add(order);
                }
                IPrinter printer = new Printer();
                //printer.PrintOrderList(orders, "orders200.json");

                // manage orders
                AssetManagementTask amt = new AssetManagementTask();
                amt.executeBatch(orders);
                // print updated and managed list
                printer.PrintOrderList(orders, "managedOrders200.json");

                Console.WriteLine("List of 200 orders, each having 20 order items created, managed and printed");
            }
        }
    }
}
