using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Calculation
{
    public interface IDeltaCalculator
    {
        double Calculate(double T, double B, double L, double Cb);

    }
}
