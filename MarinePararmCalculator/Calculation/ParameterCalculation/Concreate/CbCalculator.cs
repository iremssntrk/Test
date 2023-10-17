using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Calculation
{
    public class CbCalculator:ICbCalculator
    {
        public double Calculate(double T, double B, double L, double Delta)
        {
            double Cb = 0;
            Cb=(B*L*T)/Delta;
            return Cb;
        }
    }
}
