using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Utilities.Error
{
    public interface IDataResult<T>
    {
        T Data { get; }
        bool Result { get; }
        string Message { get; }
    }
}
