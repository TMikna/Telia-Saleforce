using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    public class OrderItem
    {
        DateTime provisioningDate; 
        
        public OrderItem() {
            ProvisioningDate = DateTime.Now;
        }

        public DateTime ProvisioningDate { get => provisioningDate; set => provisioningDate = value; }
    }
   
}
