using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Telia_Salesforece;

namespace TestProject
{
    [TestClass]
    public class AssetManagementTaskTests
    {
        [TestMethod]
        public void ExpectException() {
            Order order = new Order();
            for (int i = 0; i < 21; i++)
                order.OrderItems.Add(new OrderItem());

            List<Order> orders = new List<Order>() { order };
            AssetManagementTask amt = new AssetManagementTask();

            Assert.ThrowsException<OrchestrationUnrecoverableException>(() => amt.executeBatch(orders));
        }
    }
}
