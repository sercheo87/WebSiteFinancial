using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;
using Adapters.Interfaces.Security;
using Shared.Infrastructure.Messaging;

namespace Presentation.Security
{
    public class ChangePasswordPresenter : Presenter<IChangePasswordView>
    {
        protected IUserAdapter _adapter;

        public ChangePasswordPresenter(IUserAdapter adapter)
        {
            _adapter = adapter;
        }

        public void ChangePassword()
        {
            //TO DO: CHANGE PASSWORD METHOD
            View.ShowMessage("ChangePasswordSucceed", Icon.Information);
        }
    }
}
