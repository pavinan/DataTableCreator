using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableCreator.Attributes
{
    public class DataColumnOrderAttribute : Attribute
    {
        public int Order;
        public DataColumnOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
