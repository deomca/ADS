using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
    public interface IPriority:IPersist
    {
        IList<Priority> FindAll();
    }
}
