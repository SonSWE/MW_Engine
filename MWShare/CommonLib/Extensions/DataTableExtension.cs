using System;
using System.Data;

namespace CommonLib.Extensions
{
    public static class DataTableExtension
    {
        public static void ChangeColumnType(this DataTable table, string columnName, Type newType)
        {
            using (DataColumn dc = new DataColumn(columnName + "___changetype___", newType))
            {
                // Add the new column which has the new type, and move it to the ordinal of the old column
                int ordinal = table.Columns[columnName].Ordinal;
                table.Columns.Add(dc);
                dc.SetOrdinal(ordinal);

                // Get and convert the values of the old column, and insert them into the new
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        dr[dc.ColumnName] = Convert.ChangeType(dr[columnName], newType);
                    }
                }

                // Remove the old column
                table.Columns.Remove(columnName);

                // Give the new column the old column's name
                dc.ColumnName = columnName;
            }
        }
    }
}
