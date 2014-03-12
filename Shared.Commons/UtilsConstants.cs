using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commons
{
    public class UtilsConstants
    {
        public enum TypeProductsFilters { All, Actives, Pasives, Saving, Cheking, Loans }

        public const int PRODUCT_SAVING_ID = 4;
        public const int PRODUCT_CHECKING_ID = 3;
        public const int PRODUCT_LOANS_ID = 7;

        public static int[] ProductsActives = new int[] { PRODUCT_SAVING_ID, PRODUCT_CHECKING_ID };
        public static int[] ProductsPasives = new int[] { PRODUCT_LOANS_ID };
    }
}
