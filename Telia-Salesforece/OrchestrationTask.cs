using System;
using System.Collections.Generic;
using System.Text;

namespace Telia_Salesforece
{
    public interface OrchestrationTask
    {
        void executeBatch(List<Order> orderItemList);
}
}
