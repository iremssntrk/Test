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
        OpenFileDialog filedialog;

        public OpenFileDialogClass()
        {
            filedialog = new OpenFileDialog();
        }
        public string FileSelection(string filter)
        {
            filedialog.Filter = filter;
            if (filedialog.ShowDialog() == true)
            {
                return filedialog.FileName;
            }

            return null;
        }

    }
}
