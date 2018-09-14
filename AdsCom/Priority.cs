using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;


namespace AdsCom
{
    public class Priority:AbstractDomain
    {
        public int Priority_Id { get; set; }
        public string Priority_Name { get; set; }

        public void Save()
        {
            IPriority priority = new PriorityPersist();
            priority.Save(this);
        
        }
        public void Load(int PriorityId)
        {
            IPriority priority = new PriorityPersist();
            this.Id = PriorityId;
            priority.Load(this);
        
        }
        public void Delete(int PriorityId)
        {
            IPriority priority = new PriorityPersist();
            this.Id = PriorityId;
            priority.Delete(this);
        
        }
        
        
    }
}
