using MarinePararmCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Calculation
{
    public class DeltaCalculator: IDeltaCalculator
    {
        public double Calculate(double T, double B, double L, double Cb)
        {
            double Delta;
            Delta=T*B*L*Cb;
            return Delta;
        }
    } 
}
