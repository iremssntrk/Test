using MarinePararmCalculator.Entities;
using MarinePararmCalculator.FilePath;
using MarinePararmCalculator.Utilities.Error;
using MarinePararmCalculator.Utilities.FilePath.Abstract;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarinePararmCalculator.Utilities.FilePath
{
    public class FileManagement
    {
        IPathSelection _pathSelection;
        IFileSelection _readWriteSelection;
        public FileManagement(IPathSelection pathSelection, IFileSelection readerSelection)
        {
            _pathSelection = pathSelection;
            _readWriteSelection = readerSelection;
        }

        public IDataResult<string> FileSelection(string filter)
        {
            return _pathSelection.FileSelection(filter);    
        }

        public IResult DisplayFile(string path, ListBox ListBox)
        {
            return _readWriteSelection.DisplayFile(path, ListBox);
        }

        public IResult WriteFile(List<Parameter>calculatedParams, string path)
        {
            _readWriteSelection.ClearFile(path);
            _readWriteSelection.WriteFile(($"{"[B]",-12:f} {"[L]",-14:f} {"[T]",-13:f} {"[Cb]",-13:f} {"[Δ]",-30:f} "), path);

            foreach (Parameter param in calculatedParams)
            {
                _readWriteSelection.WriteFile($"{param.B,-11:f} {param.L,-11:f} {param.T,-11:f} {param.Cb.ToString("0.00"),-11:f} {param.Delta.ToString("0.00"),-11:f} ",path);
            }
            return new Result(true);
        }

        public void LogToFile(string Message, string path)
        {
            Message = DateTime.Now.ToString() + " : " + Message;
            _readWriteSelection.WriteFile(Message, path);
        }

    }
}
