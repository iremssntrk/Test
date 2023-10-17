using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Utilities
{
    public static class InputFormat
    {
        public static bool InputFormatCheck(string input)
        {
            return double.TryParse(input,out double result);
        }
    }
}
