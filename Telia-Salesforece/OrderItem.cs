using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    public class OrderItem
    {
        DateTime provisioningDate; 
        public DateTime ProvisioningDate { get => provisioningDate; set => provisioningDate = value; }

        public OrderItem() {
            ProvisioningDate = DateTime.Now;
        }

        
    }
   
}
