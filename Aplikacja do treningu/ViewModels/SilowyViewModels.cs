using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Aplikacja_do_treningu.Views;
using System.ComponentModel;

namespace Aplikacja_do_treningu.ViewModels
{
    public class SilowyViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
