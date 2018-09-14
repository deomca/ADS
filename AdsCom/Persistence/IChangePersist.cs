using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
   public interface IChangePersist:IPersist
    {
       IList<Change> FindAll();
       Change LoadByOrderId(int OrderId);
    }
}
