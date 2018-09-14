using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;
namespace AdsCom
{
    public class Status:AbstractDomain
    {
        public string ORDER_STATUS {get; set; }

        public void Save()
        {
            IStatusPersist persist = new StatusPersist();
            persist.Save(this);


        }
        public void Load(int StatusId)
        {

            IStatusPersist persist = new StatusPersist();
            this.Id = StatusId;
            persist.Load(this);

        }
        public void Delete(int StatusId)
        {
            IStatusPersist persist = new StatusPersist();
            this.Id = StatusId;
            persist.Delete(this);
        }
        public static IList<Status> FindAll()
        {
            IList<Status> sts = new List<Status>();
            IStatusPersist persist = new StatusPersist();
            return sts = persist.FindAll();

        }
    }
}
