using MarinePararmCalculator.Entities;
using MarinePararmCalculator.FilePath;
using MarinePararmCalculator.Utilities;
using MarinePararmCalculator.Utilities.Error;
using MarinePararmCalculator.Utilities.FilePath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.Calculation
{
    public class CalculationManager
    {
        ICbCalculator _cbCalculator;
        IDeltaCalculator _deltaCalculator;
        public CalculationManager(ICbCalculator cbCalculator,IDeltaCalculator deltaCalculator)
        {
            _cbCalculator = cbCalculator; 
            _deltaCalculator=deltaCalculator; 
        }
        public IDataResult<double> CalculateCb(string T_string, string B_string, string L_string, string Delta_string )
        {
            double Cb=0;

            if (InputFormat.InputFormatCheck(T_string) && InputFormat.InputFormatCheck(B_string) && InputFormat.InputFormatCheck(L_string) && InputFormat.InputFormatCheck(Delta_string))
            {
                double Delta = double.Parse(Delta_string);
                double T = double.Parse(T_string);
                double B = double.Parse(B_string);
                double L = double.Parse(L_string);
                Cb = _cbCalculator.Calculate(T, B, L, Delta);
                return new DataResult<double>(Cb, true);
            }
            return new DataResult<double>(false, MessageString.EmptyField);
        }

        public IDataResult<double> CalculateDelta(string T_string, string B_string, string L_string, string Cb_string)
        {
            double Delta=0;
            if (InputFormat.InputFormatCheck(T_string) &&InputFormat.InputFormatCheck(B_string)&&InputFormat.InputFormatCheck(L_string)&&InputFormat.InputFormatCheck(Cb_string))
            {
               double Cb = double.Parse(Cb_string);
                double T = double.Parse(T_string);
                double B = double.Parse(B_string);
                double L = double.Parse(L_string);
                Delta = _deltaCalculator.Calculate(T, B, L, Cb);
                return new DataResult<double>(Delta, true);
            }
            return new DataResult<double>(false, MessageString.EmptyField);
        }

        public IDataResult<List<Parameter>> CalculateAndPrint(string T_string, string B_string, string L_string, string Cb_string, string Delta_string, string pathCalculation)
        {
            List<Parameter> calculatedParams = new List<Parameter>();

            if (InputFormat.InputFormatCheck(T_string) && InputFormat.InputFormatCheck(B_string) && InputFormat.InputFormatCheck(L_string) && InputFormat.InputFormatCheck(Cb_string)&& InputFormat.InputFormatCheck(Delta_string))
            {
                double Delta = double.Parse(Delta_string);
                double Cb = double.Parse(Cb_string);
                double T = double.Parse(T_string);
                double B = double.Parse(B_string);
                double L = double.Parse(L_string);


                for (int i = 0; i < 6; i++)
                {
                    Parameter TempEntity = new Parameter();
                    TempEntity.Delta = Delta * i / 5;
                    calculatedParams.Add(TempEntity);
                }

                foreach (var item in calculatedParams)
                {
                    item.Cb = _cbCalculator.Calculate(T, B, L, item.Delta);
                    item.B = B;
                    item.T= T;
                    item.L = L;

                }
                var fileIOManagement = new FileManagement(new OpenFileDialogClass(), new StreamReaderClass());
                fileIOManagement.WriteFile(calculatedParams, pathCalculation);
                return new DataResult<List<Parameter>>(calculatedParams, true, MessageString.PrintOK);
            }
            return new DataResult<List<Parameter>>(false, MessageString.EmptyField);
        }


    }
}
