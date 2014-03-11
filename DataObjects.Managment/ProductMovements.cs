using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Managment
{
    [Serializable]
    public class ProductMovements
    {
        public DateTime Date { get; set; }
        public double AmmountTransfer { get; set; }
        public string Description { get; set; }
        public string TypeTransfer { get; set; }
    }
}
