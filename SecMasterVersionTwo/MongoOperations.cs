using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecMasterVersionTwo
{
    class MongoOperations:IFactoryBase
    {
        public void Insert(string file_path, string values_to_be_inserted)
        {
            //insertion operations according to the MongoDB syntax   
        }
        public void Update(string field_names, string values_to_be_updated)
        {
            //updation operations according to the MongoDB syntax
        }
        public void Delete(string sec_id)
        {
            //deletion operation according to the MongoDB syntax
        }
    }
}
