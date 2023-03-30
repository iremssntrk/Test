using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineParamCalculatorMustafa
{
    internal class Model
    {
        public double B { get; private set; }
        public double L { get; private set; }
        public double T { get; private set; }
        public double Cb { get; private set; } = 1;
        public double Delta { get; private set; }

        public void SetB(double value)
        {
            this.B = value;
            RenewDelta();
        }
        public void SetL(double value)
        {
            this.L = value;
            RenewDelta();
        }
        public void SetT(double value)
        {
            this.T = value;
            RenewDelta();
        }
        public void SetDelta(double value)
        {
            Delta = value;
            RenewCb();
        }

        public void SetCb(double value)
        {
            Cb = value;
            RenewDelta();
        }

        public void RenewDelta()
        {
            Delta = Cb * B * T * L;
        }
        public void RenewCb()
        {
            Cb = Delta / (B * T * L);
        }
        public Model Clone()
        {
            Model newModel = new Model { B=this.B, L=this.L, T=this.T, Cb = this.Cb, Delta = this.Delta };
            return newModel;
        }
        public override string ToString()
        {
            return $"B:{B,-11:f} L:{L,-11:f} T:{T,-11:f} Cb:{Cb,-11:f} Delta:{Delta,-11:f}";
        }
    }
}
