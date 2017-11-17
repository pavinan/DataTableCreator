using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableCreator.Attributes
{
    public class DataColumnNameAttribute : Attribute
    {
        public string Name;
        public DataColumnNameAttribute(string name)
        {
            Name = name;
        }
    }
}
