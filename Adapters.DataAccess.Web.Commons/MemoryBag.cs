using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Adapters.Interfaces.Commons;

namespace Adapters.DataAccess.Web.Commons
{
    public class MemoryBag : IMemoryBag
    {
        public object this[string key]
        {
            get { return HttpContext.Current.Session[key]; }
            set { HttpContext.Current.Session[key] = value; }
        }

        public bool Contains(string key)
        {
            foreach (string item in HttpContext.Current.Session.Keys)
                if (string.Compare(item, key, false) == 0)
                    return true;

            return false;
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        public void Clear()
        {
            List<string> keys = new List<string>(new string[] { "CultureName", "Theme", "VerticalMenu.LastKey" });
            Dictionary<string, object> values = new Dictionary<string, object>();

            foreach (string key in keys)
                values[key] = HttpContext.Current.Session[key];

            HttpContext.Current.Session.Clear();

            foreach (string key in keys)
                HttpContext.Current.Session[key] = values[key];
        }
    }
}
