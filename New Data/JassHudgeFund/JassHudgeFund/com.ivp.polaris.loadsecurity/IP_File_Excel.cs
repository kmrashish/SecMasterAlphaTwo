using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.loadsecurity
{
    public partial interface IP_File_Excel
    {
        bool Write(string fileName, DataSet ds);

        DataTable Read(string excelFile, string sheetName);
    }
}
