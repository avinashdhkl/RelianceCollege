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

        public List<T0> DataWithListObject<T0>(string storeProducer, object param)
        {
            try
            {
                var resp = _execute.ExecuteQuery<T0>(storeProducer, param);
                return resp;
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public T0 DatawithSingleObject<T0>(string storeProducer, object param)
        {
            try
            {
                var resp = _execute.ExecuteQuery<T0>(storeProducer, param);
                return resp.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
