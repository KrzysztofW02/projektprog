using QuizApp.Views;
using GalaSoft.MvvmLight.Command;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Wybierz rodzaj Quizu";

        public ICommand OpenMatematykaCommand { get; }
        public ICommand OpenInformatykaCommand { get; }

        public MainWindowViewModel()
        {
            OpenMatematykaCommand = new RelayCommand(OpenMatematyka);
            OpenInformatykaCommand = new RelayCommand(OpenInformatyka);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OpenMatematyka()
        {
            // Tutaj otwieramy nowe okno "Matematyka.axaml"
            var matematykaWindow = new Matematyka();
            matematykaWindow.Show();
        }

        private void OpenInformatyka()
        {
            // Tutaj otwieramy nowe okno "Matematyka.axaml"
            var InformatykaWindow = new Informatyka();
            InformatykaWindow.Show();
        }
    }
}