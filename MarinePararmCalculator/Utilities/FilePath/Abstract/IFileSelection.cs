using MarinePararmCalculator.Entities;
using MarinePararmCalculator.Utilities.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarinePararmCalculator.Utilities.FilePath.Abstract
{
    public interface IFileSelection
    {
        IResult DisplayFile(string path, ListBox ListBox);

        IResult WriteFile(string message, string Path);

        void ClearFile(string Path);
    }
}
