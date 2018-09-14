using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
    public interface IInstructionsPersist:IPersist
    {
        IList<Instructions> FindAll();
        IList<Instructions> LoadByOrderId(int OrderId);
    }
}
