using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Utilities.Error
{
    public class Result:IResult
    {
        public Result(bool _result, string message):this(_result)
        {
            Message = message;
        }

        public Result(bool _result)
        {
            result = _result;
        }

        public bool result { get; }

        public string Message { get; }

       
    }
}
