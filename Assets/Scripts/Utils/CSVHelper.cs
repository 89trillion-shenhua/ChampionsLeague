using System.IO;

namespace Utils
{
    public class CSVHelper
    {
        public static System.Data.DataTable CsvToDataTable(string filePath, int n)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default, false);
            int m = 0;
            while (!reader.EndOfStream)
            {
                m = m + 1;
                string str = reader.ReadLine();
                if (str != null)
                {
                    string[] split = str.Split(',');
                    if (m == n)
                    {
                        System.Data.DataColumn column ; //列名
                        for (int c = 0; c < split.Length;c++ )
                        {
                            column = new System.Data.DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = split[c];
                            if (dt.Columns.Contains(split[c])) //重复列名处理
                            {
                                column.ColumnName = split[c] + c;
                            }
                            dt.Columns.Add(column);
                        }
                    }
                    if (m >= n + 1)
                    {
                        System.Data.DataRow dr = dt.NewRow();
                        for (int i = 0; i < split.Length; i++)
                        {
                            dr[i] = split[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            reader.Close();
            return dt;
        }
    }
}