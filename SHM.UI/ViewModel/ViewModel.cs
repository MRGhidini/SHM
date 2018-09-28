using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        public ViewModelLocator Locator { get; set; }
        public ViewModel(ViewModelLocator locator)
        {
            Locator = locator;
        }
    }
}
