using MarinePararmCalculator.Utilities.Error;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePararmCalculator.FilePath
{
    class OpenFileDialogClass:IPathSelection
    {
        OpenFileDialog filedialog = new OpenFileDialog();

        public IDataResult<string> FileSelection(string filter)
        {
            filedialog.Filter = filter;
            if (filedialog.ShowDialog() == true)
            {
                return new DataResult<string>(filedialog.FileName, true);
                    
            }

            return new DataResult<string>(false, "Dosya adresi bulunamadı");
        }

    }
}
