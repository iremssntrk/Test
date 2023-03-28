using MarinePararmCalculator.Utilities.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.FilePath
{
    public interface IPathSelection
    {
        IDataResult<string> FileSelection(string filter);
}
     }
