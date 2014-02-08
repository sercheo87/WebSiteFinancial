using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;

namespace Presentation.Security
{
    public interface ILoginView : IView
    {
        string Username { get; }
        string Password { get; }
        void DoAuthenticateSuccess();
    }
}
