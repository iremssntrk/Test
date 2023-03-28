using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Utilities.Error
{
    public interface IResult
    {
        string Message { get; }
        bool result { get; }

    }
}
