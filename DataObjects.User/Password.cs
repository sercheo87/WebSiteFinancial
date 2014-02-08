using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.User
{
    public class Password
    {
        public string EntityID { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
