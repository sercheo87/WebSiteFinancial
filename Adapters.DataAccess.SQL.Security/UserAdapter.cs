using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adapters.Interfaces.Security;
using DataObjects.User;

namespace Adapters.DataAccess.SQL.Security
{
    public class UserAdapter : IUserAdapter
    {
        public Entity GetUserInformation(Entity entity)
        {
            //TO DO: Get user information according to entity.Username value
            return new Entity() { ID = 0, Username = "xhurtado", FirstLastName = "Hurtado", SecondLastName = "García", Names = "Guillermo Xavier", EMail = "xhurtado@cobiscorp.com" };
        }
        
        public bool Authenticate(Entity entity)
        {
            //TO DO: Authenticate and retrive permisions
            return true;
        }
        
        public void Logout()
        {
        }

        public void ChangePassword()
        {
        }
    }
}
