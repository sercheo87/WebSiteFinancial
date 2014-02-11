using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects.User;

namespace Adapters.Interfaces.Security
{
    public interface IUserAdapter
    {
        Entity GetUserInformation(Entity entity);
        bool Authenticate(Entity entity);
        void Logout();
        void ChangePassword();
    }
}
