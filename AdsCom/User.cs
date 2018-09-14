using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;

namespace AdsCom
{
    public class User : AbstractDomain
    {
        public string RealName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
         public int STATUS_ID { get; set; }           

        public void Save()
        {
            IUserPersist persist = new UserPersist();
            persist.Save(this);
            

        }
        public void Load(int UserId)
        {
           
            IUserPersist persist = new UserPersist();
            this.Id = UserId;
            persist.Load(this);

        }
        public void Delete(int UserId)
        {
            IUserPersist persist = new UserPersist();
            this.Id = UserId;
            persist.Delete(this);
        }
        public static IList<User> FindAll()
        {
            IList<User> usr = new List<User>();
            IUserPersist persist = new UserPersist();
            return usr = persist.FindAll();

        }
        public static User Authenticate(string loginid, string password, User u)
        {
            IUserPersist persist = new UserPersist();
            return persist.Authenticate(loginid, password, u);

        }
        public static IList<User> LoadByUserStatusId(int StatusId)
        {
            IList<User> u = new List<User>();
            IUserPersist persist = new UserPersist();
            return u = persist.LoadByUserStatusId(StatusId);

        }
    }
}
