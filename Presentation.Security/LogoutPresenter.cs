using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;
using Adapters.Interfaces.Security;
using Shared.Commons;

namespace Presentation.Security
{
    public class LogoutPresenter : Presenter<ILogoutView>
    {
        protected IUserAdapter _adapter;

        public LogoutPresenter(IUserAdapter adapter)
        {
            _adapter = adapter;
        }

        public void Logout()
        {
            //TO DO: LOGOUT PROCESS
            View.DoLogoutSuccess();
            MemoryBag.Current.Clear();
        }
    }
}
