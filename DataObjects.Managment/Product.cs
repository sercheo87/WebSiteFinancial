using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Managment
{
    [Serializable]
    public class Product
    {
        public string Account { get; set; }
        public int Type { get; set; }
        public double AmmountAvailable { get; set; }
        public int Currency { get; set; }
        public string Name { get; set; }
    }
}
