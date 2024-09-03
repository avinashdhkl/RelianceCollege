using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Execute
{
    public interface IExecute
    {
        List<object> ExecuteQuery<T0,T1>(string SqlQuery,object SqlParam,CommandType type=CommandType.StoredProcedure);
    }
}
