using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;

namespace Presentation.Security
{
    public interface IChangePasswordView : IView
    {
        string Password { get; }
        string NewPassword { get; }
        string ConfirmPassword { get; }
    }
}
