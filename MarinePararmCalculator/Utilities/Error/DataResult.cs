using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Utilities.Error
{
    public class DataResult<T> : IDataResult<T>
    {


        public DataResult(T data, bool result, string message):this(data, result)
        {
            Message = message;
        }

        public DataResult(bool _result, string message)
        {
            Result = _result;
            Message = message;

        }

        public DataResult(T data,bool result)
        {
            Data = data;
            Result = result;
        }


        public T Data { get; }

        public bool Result { get; }

        public string Message { get; }


    }
}
