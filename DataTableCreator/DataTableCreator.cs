using DataTableCreator.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataTableCreator
{
    public class DataTableCreator<T>
    {

        private readonly DataTable _underlyingDataTable = new DataTable();

        private List<KeyValuePair<string, PropertyDetails>> _propertyCache = new List<KeyValuePair<string, PropertyDetails>>();

        private DataTableCreator()
        {

        }

        public DataTable GetDataTable()
        {
            return _underlyingDataTable;
        }

        public static DataTableCreator<T> GetCreator()
        {
            var creator = new DataTableCreator<T>();

            var dataType = typeof(T);

            foreach (var propertyItem in dataType.GetProperties())
            {
                var details = new PropertyDetails
                {
                    PropertyInfo = propertyItem
                };

                var propName = propertyItem.Name;

                var nameAttr = propertyItem.GetCustomAttributes<DataColumnNameAttribute>();

                if(nameAttr.Any())
                {
                    details.DataColumnName = nameAttr.First();
                }

                creator._propertyCache.Add(new KeyValuePair<string, PropertyDetails>(propName, details));
            }

            return creator;
        }

        private class PropertyDetails
        {
            public PropertyInfo PropertyInfo { get; set; }
            public DataColumnNameAttribute DataColumnName { get; set; }
            public int Order { get; set; }
        }

    }
}
