using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BussMan.Common
{
    public class ConvertFun<T> where T : class,new()
    {
        public static List<T> TableToList(DataTable table)
        {
            List<T> res = new List<T>();
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    T item = new T();
                    foreach(DataColumn column in table.Columns)
                    {
                        try
                        {
                            PropertyInfo prop = item.GetType().GetProperty(column.ColumnName);
                            object obj = table.Rows[i][column.ColumnName];
                            prop.SetValue(item, obj);
                        }catch { }
                    }
                    res.Add(item);
                }
            }
            return res;
        }

        public static T TableToItem(DataTable table)
        {
            T res = new T();
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        try
                        {
                            PropertyInfo prop = res.GetType().GetProperty(column.ColumnName);
                            object obj = table.Rows[i][column.ColumnName];
                            prop.SetValue(res, obj);
                        }
                        catch { }
                    }
                }
            }
            return res;
        }

    }
}
