using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;

namespace AdsCom
{
    public class Change : AbstractDomain
    {
        public int Order_Id { get; set; }
        public string Design_By_Name { get; set; }
        public int Design_By_Id { get; set; }
        public int Qa_By_Id { get; set; }
        public string Qa_By_Name { get; set; }

        public void Save()
        {
            IChangePersist persist = new ChangePersist();
            persist.Save(this);


        }
        public void Load(int ChangeId)
        {
            IChangePersist persist = new ChangePersist();
            this.Id = ChangeId;
            persist.Load(this);

        }

        public void Delete(int ChangeId)
        {
            IChangePersist persist = new ChangePersist();
            this.Id = ChangeId;
            persist.Delete(this);
        }

        public IList<Change> FindAll()
        {
            IList<Change> ch = new List<Change>();
            IChangePersist persist = new ChangePersist();
            return ch = persist.FindAll();

        }

        public Change LoadByOrderId(int OrderId)
        {
            IChangePersist persist = new ChangePersist();
          
           return persist.LoadByOrderId(OrderId);
        }
    }
}
