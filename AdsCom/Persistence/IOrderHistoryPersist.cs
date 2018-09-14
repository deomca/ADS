using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
    public interface IOrderHistoryPersist:IPersist
    {
        IList<OrderHistory> FindAll();
        IList<OrderHistory> LoadByOrderId(int OrderId);
    }
}
