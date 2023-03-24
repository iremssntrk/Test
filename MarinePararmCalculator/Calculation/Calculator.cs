using MarinePararmCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Calculation
{
    public class Calculator
    {
        public List<CalculationParameter> Delta(CalculationParameter calculationParameter)
        {
            List<CalculationParameter> calculatedParams=new List<CalculationParameter>();


            for (int i = 0; i < 6; i++)
            {
                CalculationParameter TempEntity = new CalculationParameter();
                TempEntity.Delta = calculationParameter.Delta * i / 5;
                calculatedParams.Add(TempEntity);   

            }

            return calculatedParams;
        } 

        public void Cb(ref List<CalculationParameter> calculationParameters, CalculationParameter calculationParameter) 
        {

            foreach (var calcParam in calculationParameters)
            {
                if (calcParam.Delta != 0)
                {
                    calcParam.Cb = (calculationParameter.B * calculationParameter.L * calculationParameter.T / calcParam.Delta);
                }
                else
                {
                    calcParam.Cb = 0;
                }
            }
        }    
    }
}
