using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineParamCalculatorMustafa
{
    internal class Calculator
    {
        List<Model> results;
        Logger _logger;
        public Calculator(Model model, int stepSize, Logger logger = null)
        {
            _logger = logger;
            results = new List<Model>();
            double T_target = model.T;
            for(int i = 0; i < stepSize; i++)
            {
                double t = i * T_target / stepSize;
                model.SetT(t);
                results.Add(model.Clone());
            }
            _logger?.Log(ToString());
        }

        public void WriteReultsToFile(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string output = this.ToString();
            
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(path, output);
        }

        public List<string> ToStringList()
        {
            List<string> list = new List<string>();
            foreach (Model model in results)
            {
                list.Add(model.ToString());
            }
            return list;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Model model in results)
            {
                sb.AppendLine(model.ToString());
            }
            return sb.ToString();
        }
    }
}
