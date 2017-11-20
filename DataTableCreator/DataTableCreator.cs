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

        public DataTableCreator<T> Add(T data)
        {
            var row = _underlyingDataTable.NewRow();

            foreach (var propertyItem in _propertyCache)
            {
                var columnValue = propertyItem.Value.PropertyInfo.GetValue(data);

                row[propertyItem.Value.ColumnName] = columnValue;

            }

            _underlyingDataTable.Rows.Add(row);

            return this;
        }

        public DataTableCreator<T> AddRange(IEnumerable<T> dataList)
        {
            foreach (var item in dataList)
                Add(item);

            return this;
        }


        private void CreateDataTable()
        {
            foreach (var item in _propertyCache)
            {
                var columnName = item.Value.DataColumnName?.Name ?? item.Value.PropertyInfo.Name;

                item.Value.ColumnName = columnName;

                _underlyingDataTable.Columns.Add(columnName, item.Value.PropertyInfo.PropertyType);

            }
        }

        public static DataTableCreator<T> GetCreator()
        {
            var creator = new DataTableCreator<T>();

            var dataType = typeof(T);

            foreach (var propertyItem in dataType.GetProperties())
            {
                if (!IsSimple(propertyItem.PropertyType))
                    continue;

                var details = new PropertyDetails
                {
                    PropertyInfo = propertyItem
                };

                var propName = propertyItem.Name;

                var nameAttr = propertyItem.GetCustomAttributes<DataColumnNameAttribute>();

                if (nameAttr.Any())
                {
                    details.DataColumnName = nameAttr.First();
                }

                creator._propertyCache.Add(new KeyValuePair<string, PropertyDetails>(propName, details));
            }

            creator.CreateDataTable();

            return creator;
        }

        static bool IsSimple(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimple(type.GetGenericArguments()[0]);
            }
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal))
              || type.Equals(typeof(DateTime))
              || type.Equals(typeof(DateTimeOffset));
        }

        private class PropertyDetails
        {
            public PropertyInfo PropertyInfo { get; set; }
            public DataColumnNameAttribute DataColumnName { get; set; }
            public string ColumnName { get; set; }
            public int Order { get; set; }
        }

    }
}
