using MarinePararmCalculator.Entities;
using MarinePararmCalculator.FilePath;
using MarinePararmCalculator.Utilities.Error;
using MarinePararmCalculator.Utilities.FilePath.Abstract;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MarinePararmCalculator.Utilities.FilePath
{
    public class FileManagement
    {
        IPathSelection _pathSelection;
        IFileSelection _readerSelection;
        public FileManagement(IPathSelection pathSelection, IFileSelection readerSelection)
        {
            _pathSelection = pathSelection;
            _readerSelection = readerSelection;
        }

        public IDataResult<string> FileSelection(string filter)
        {
            return _pathSelection.FileSelection(filter);    
        }

        public IResult DisplayFile(string path, ListBox ListBox)
        {
            return _readerSelection.DisplayFile(path, ListBox);
        }

        public IResult WriteFile(List<Parameter>calculatedParams, string path)
        {
            return _readerSelection.WriteFile(calculatedParams, path);
        }

    }
}
