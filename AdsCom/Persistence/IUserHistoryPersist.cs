using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
    public interface IUserHistoryPersist:IPersist
    {
        IList<UserHistory> FindAll();
        UserHistory LoadByUserId(int UserId);
        IList<UserHistory> LoadByOrderId(int OrderId);
    }
}
