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
        Parameter Model { get; set; }
        public CalculationManager(Parameter model, ICbCalculator cbCalculator,IDeltaCalculator deltaCalculator)
        {
            Model = model;
            _cbCalculator = cbCalculator; 
            _deltaCalculator=deltaCalculator; 
        }
        public IDataResult<double> CalculateCb()
        {
            double Cb=0;
            Cb = _cbCalculator.Calculate(Model.T, Model.B, Model.L, Model.Delta);
            return new DataResult<double>(Cb, true);
        }

        public IDataResult<double> CalculateDelta()
        {
            double Delta=0;

            Delta = _deltaCalculator.Calculate(Model.T, Model.B, Model.L, Model.Cb);
            return new DataResult<double>(Delta, true);

        }

        public IDataResult<List<Parameter>> CalculateAndPrint(string pathCalculation, string pathLog)
        {
            List<Parameter> calculatedParams = new List<Parameter>();

                for (int i = 0; i < 6; i++)
                {
                    Parameter TempEntity = new Parameter();
                    TempEntity.Delta = Model.Delta * i / 5;
                    calculatedParams.Add(TempEntity);
                }

                foreach (var item in calculatedParams)
                {
                    item.Cb = _cbCalculator.Calculate(Model.T, Model.B, Model.L, item.Delta);
                    item.B = Model.B;
                    item.T= Model.T;
                    item.L = Model.L;

                }
                var fileIOManagement = new FileManagement(new OpenFileDialogClass(), new StreamRWClass());
                fileIOManagement.WriteFile(calculatedParams, pathCalculation);
                fileIOManagement.LogToFile(MessageString.PrintOK, pathLog);
                return new DataResult<List<Parameter>>(calculatedParams, true, MessageString.PrintOK);

        }


    }
}
