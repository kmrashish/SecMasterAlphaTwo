using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecMasterVersionTwo
{
    public interface IFactoryBase
    {
        //void ExecuteProcedure();
        void Update(string field_names, string values_to_be_updated);
        void Delete(string sec_id);
    }
        
}
