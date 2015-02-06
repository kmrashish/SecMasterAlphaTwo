using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.loadsecurity
{
    public partial class P_Raw_Csv:IP_File_Csv
    {
        public DataTable Read(string filePath, char sepration = ';')
        {
            try
            {
                var flag = false;
                DataTable dv = new DataTable();
                var reader = new StreamReader(File.OpenRead(@filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(sepration);
                    if (!flag)
                    {
                        foreach (var temp in values)
                            dv.Columns.Add(temp);
                        flag = true;
                    }
                    else
                    {
                        dv.Rows.Add(values);
                    }

                }
                return dv;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Write(string fileName, DataSet ds)
        {
            throw new NotImplementedException();
        }
    }
}
