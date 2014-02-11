using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;

namespace Presentation.Security
{
    public interface ILogoutView : IView
    {
        void DoLogoutSuccess();
    }
}
