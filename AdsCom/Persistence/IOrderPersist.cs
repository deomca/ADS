using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
   public interface IOrderPersist:IPersist
    {
       IList<Order> FindAll();
       IList<Order> LoadByStatusId(int StatusId);
       IList<Order> LoadByOrderDate(DateTime OrderDate, int UserId);
       IList<Order> LoadByUserId(int UserId);
       IList<Order> LoadByStatusIdandUserId(string StatusId, string UserId);
       IList<Order> LoadByOrderId(int OrderId);
    }
}
