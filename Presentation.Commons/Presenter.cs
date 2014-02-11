using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentation.Commons
{
    public class Presenter<VIEW_INTERFACE_TYPE>
    {
        public VIEW_INTERFACE_TYPE View { get; set; }
    }
}
