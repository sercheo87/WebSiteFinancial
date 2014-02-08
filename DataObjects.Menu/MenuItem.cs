using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Menu
{
    public class MenuItem
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Resource { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
