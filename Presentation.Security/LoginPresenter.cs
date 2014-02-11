using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;
using Adapters.Interfaces.Security;
using Shared.Infrastructure.Messaging;

namespace Presentation.Security
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        protected IUserAdapter _adapter;

        public LoginPresenter(IUserAdapter adapter)
        {
            _adapter = adapter;
        }

        public void Authenticate()
        {
            //TO DO: AUTHENTICATION PROCESS
            if (View.Username == "admin" && View.Password == "12345678")
            {
                View.DoAuthenticateSuccess();
            }
            else
            {
                View.ShowMessage("AuthenticationError", Icon.Error);
            }
        }
    }
}
