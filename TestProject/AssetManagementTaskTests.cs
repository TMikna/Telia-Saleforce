using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Telia_Salesforece;

namespace TestProject
{
    [TestClass]
    public class AssetManagementTaskTests
    {
        [TestMethod]
        public void ExceptionThrown() {
            Order order = new Order();
            for (int i = 0; i < 21; i++)
                order.OrderItems.Add(new OrderItem());

            List<Order> orders = new List<Order>() { order };
            AssetManagementTask amt = new AssetManagementTask();

            Assert.ThrowsException<OrchestrationUnrecoverableException>(() => amt.executeBatch(orders));
        }
        [TestMethod]
        public void ProvisioningDateUpdated() {
            Order order = new Order();
            OrderItem orderItem = new OrderItem();

            //create date which is assigned to order item and later compared if it is successfully updated
            DateTime date = DateTime.Now;
            orderItem.ProvisioningDate = date;

            order.OrderItems.Add(orderItem);
            List<Order> orders = new List<Order>() { order };
            AssetManagementTask amt = new AssetManagementTask();
            amt.executeBatch(orders);

            Assert.AreNotEqual(date, orders[0].OrderItems[0].ProvisioningDate, "Order item ProvisioninDate was not updated by executeBatch() method");
        }

        [TestMethod]
        public void ItemCountUpdated() {
            Order order = new Order();

            List<Order> orders = new List<Order>() { order };
            AssetManagementTask amt = new AssetManagementTask();
            amt.executeBatch(orders);
            Assert.AreEqual(0, orders[0].ItemCount, $"ItemCount failed to update. Expected: 0, Actual: {orders[0].ItemCount}");


            for (int i = 0; i < 2; i++)
                order.OrderItems.Add(new OrderItem());
            amt.executeBatch(orders);
            Assert.AreEqual(2, orders[0].ItemCount, $"ItemCount failed to update. Expected: 2, Actual: {orders[0].ItemCount}");
        }

        [TestMethod]
        public void SucessWithManyOrders() {
            List<Order> orders = new List<Order>();
            for(int i = 0; i<200; i++)
            {
                Order order = new Order();
                for (int j = 0; j < 20; j++)
                    order.OrderItems.Add(new OrderItem());
                orders.Add(order);
            }
           
            AssetManagementTask amt = new AssetManagementTask();


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            amt.executeBatch(orders);
            stopWatch.Stop();
            long excecutionTime = stopWatch.ElapsedMilliseconds;
            Assert.IsTrue(excecutionTime < 100, $"Processing 200 orders took {excecutionTime/1000f} seconds, expected: less than 0.1s");        
        }
    }
}
