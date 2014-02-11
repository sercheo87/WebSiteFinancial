using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;

namespace Presentation.Test
{
    public interface IDataInput : IView
    {
        string Code { get; }
    }
}
