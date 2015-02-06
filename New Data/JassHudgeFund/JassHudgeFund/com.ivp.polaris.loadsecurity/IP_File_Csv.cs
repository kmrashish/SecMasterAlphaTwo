using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.ivp.polaris.loadsecurity
{
    public partial interface IP_File_Csv
    {
        bool Write(string fileName, DataSet ds);

        DataTable Read(string filePath, char sepration);
    }
}
