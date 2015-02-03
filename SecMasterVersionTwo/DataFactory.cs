using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SecMasterVersionTwo
{
    class DataFactory
    {
        static public IFactoryBase CreateAndReturnObj(string DBType)
        {
            IFactoryBase objSelector = null;

            switch (DBType)
            {
                case "SQL":
                    objSelector = new ivp_secm_DAL();
                    break;
                case "ORACLE":
                    objSelector = new OracleOperations();
                    break;
                case "MongoDB":
                    objSelector = new MongoOperations();
                    break;
                default:
                    Debug.Write("invalid DB Type");
                    break;              
            }
            return objSelector;
        }
    }
}
