using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AdsCom.Persistence
{
   public interface IUserPersist:IPersist
    {
        IList<User> FindAll();
        User Authenticate(string loginid, string password, User u);
        IList<User> LoadByUserStatusId(int StatusId);
    }
}