using DatabaseLayer.Execute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Drapper
{
    public class Drapper : IDrapper
    {
        private readonly IExecute _execute;

        public Drapper(IExecute execute)
        {
            _execute = execute;
        }

        public List<object> DatawithMultiple<T0, T1>(string storeProducer, object param)
        {
            try
            {
                var resp = _execute.ExecuteQuery<T0,T1>(storeProducer, param);
                return resp.ToList();
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
