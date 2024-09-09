using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Drapper
{
    public interface IDrapper
    {
        List<object> DatawithMultiple<T0, T1>(string storeProducer,object param);
        T0 DatawithSingleObject<T0>(string storeProducer, object param);
        List<T0> DataWithListObject<T0>(string storeProducer,object param);
    }
}
