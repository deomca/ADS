using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;

namespace AdsCom
{
    public class UserHistory : AbstractDomain
    {
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public string Comments { get; set; }
        public int Status_Id { get; set; }
        public DateTime Allocated_Date { get; set; }
        public DateTime Submitted_Date { get; set; }
        public int Images { get; set; }
        public int Pages { get; set; }
        public DateTime Totaltime { get; set; }
        
        public void Save()
        {
            IUserHistoryPersist persist = new UserHistoryPersist();
            persist.Save(this);

        }
        public void Load(int UserHisId)
        {

            IUserHistoryPersist persist = new UserHistoryPersist();
            this.Id = UserHisId;
            persist.Load(this);

        }
        public void Delete(int UserHisId)
        {
            IUserHistoryPersist persist = new UserHistoryPersist();
            this.Id = UserHisId;
            persist.Delete(this);
        }
        public static IList<UserHistory> FindAll()
        {
            IList<UserHistory> usr = new List<UserHistory>();
            IUserHistoryPersist persist = new UserHistoryPersist();
            return usr = persist.FindAll();

        }
        public UserHistory LoadByUserId(int UserId)
        {            
            IUserHistoryPersist persist = new UserHistoryPersist();
           return persist.LoadByUserId(UserId);

        }
        public static IList<UserHistory> LoadByOrderId(int OrderId)
        {
            IList<UserHistory> u = new List<UserHistory>();
            IUserHistoryPersist persist = new UserHistoryPersist();
            return u = persist.LoadByOrderId(OrderId);

        }
    }
}
