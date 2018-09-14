using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdsCom.Persistence
{
    public interface IPersist
    {
        void Load(AbstractDomain domain);
        void Save(AbstractDomain domain);
        void Delete(AbstractDomain domain);
    }
}
