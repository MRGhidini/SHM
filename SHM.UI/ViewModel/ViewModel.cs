using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            LaunchCommand = new RelayCommand<string>(Launch);
        }

        public RelayCommand<string> LaunchCommand { get; protected set; }
        void Launch(string item) => Process.Start(item);
    }
}
