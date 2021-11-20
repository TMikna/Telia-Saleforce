using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    public class AssetManagementTask : OrchestrationTask
    {
        //to be possible to write a check for recoverable Error, in real code it shoud be thrown when actual errro happens
        bool recoverableErrorHappened = false; 

        public void executeBatch(List<Order> orderItemList) {
            foreach (Order order in orderItemList)
            {
                foreach(OrderItem orderItem in order.OrderItems)
                {
                    // Update ProvisioningDate with current date
                    orderItem.ProvisioningDate = DateTime.Now;
                }
                // Update item count
                order.ItemCount = order.OrderItems.Count;

                // check fore exceptions
                if (recoverableErrorHappened)
                    throw new OrchestrationRecoverableException();
                //this exception might supposed to be before assigning order.ItemCount, howewer I have order in the task
                if (order.ItemCount > 20)
                    throw new OrchestrationUnrecoverableException();
            }


            /* Was I supposed to do it with a database?
             * 
             * That way it could get list or orders IDs, get them by ID from database, then
             * each order should have IDs of their order items by which they could be retrieved from database as well
             * So for each order we should then retrieve it's order items, update and count them then update orders
             * 
             */
        }
    }
}
