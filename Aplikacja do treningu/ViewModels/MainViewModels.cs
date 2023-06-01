using Aplikacja_do_treningu.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Aplikacja_do_treningu.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenSilowyCommand { get; }

        public MainViewModel()
        {
            OpenSilowyCommand = new RelayCommand(OpenSilowyWindow);
        }

        private void OpenSilowyWindow()
        {
            SilowyView silowyWindow = new SilowyView();
            silowyWindow.Show();
        }
    }
}
