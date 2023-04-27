using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Aplikacja_do_treningu.Views;

namespace Aplikacja_do_treningu.ViewModels
{
    public class SilowyViewModel : ViewModelBase
    {
        public ICommand OpenLatwyCommand { get; }
        public ICommand OpenNormalnyCommand { get; }
        public ICommand OpenTrudnyCommand { get; }

        public SilowyViewModel()
        {
            OpenLatwyCommand = new RelayCommand(OpenLatwyWindow);
            OpenNormalnyCommand = new RelayCommand(OpenNormalnyWindow);
            OpenTrudnyCommand = new RelayCommand(OpenTrudnyWindow);
        }

        private void OpenLatwyWindow()
        {
            Latwy latwyWindow = new Latwy();
            latwyWindow.Show();
        }
        private void OpenNormalnyWindow()
        {
            Normalny normlanyWindow = new Normalny();
            normlanyWindow.Show();
        }
        private void OpenTrudnyWindow()
        {
            TrudnyView trudnyWindow = new TrudnyView();
            trudnyWindow.Show();
        }
    }
}
