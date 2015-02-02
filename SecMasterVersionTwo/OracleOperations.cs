using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecMasterVersionTwo
{
    public class OracleOperations:IFactoryBase
    {
        public void Insert(string file_path, string values_to_be_inserted)
        {
            //insertion operations according to the ORACLE syntax   
        }
        public void Update(string field_names, string values_to_be_updated)
        {
            //updation operations according to the ORACLE syntax
        }
        public void Delete(string sec_id)
        {
            //deletion operation according to the ORACLE syntax
        }
    }
}
