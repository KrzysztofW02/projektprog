using Aplikacja_do_treningu.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Collections;
using System.Numerics;
using System.Windows.Threading;
using System.Windows;
using System.Data.Common;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aplikacja_do_treningu.ViewModels
{
    public class LatwyViewModels : INotifyPropertyChanged
    {
        private DispatcherTimer timer;
        private int time;
        private int phase;
        private bool paused;

        private string _czasText;
        private string _napisText;
        public string CzasText
        {
            get { return _czasText; }
            set
            {
                if (_czasText != value)
                {
                    _czasText = value;
                    OnPropertyChanged(nameof(CzasText));
                }
            }
        }

        public Visibility CzasVisibility
        {
            get { return _czasVisibility; }
            set
            {
                _czasVisibility = value;
                OnPropertyChanged(nameof(CzasVisibility)); 
            }
        }

        public string NapisText
        {
            get { return _napisText; }
            set
            {
                if (_napisText != value)
                {
                    _napisText = value;
                    OnPropertyChanged(nameof(NapisText));
                }
            }
        }

        public Visibility NapisVisibility
        {
            get { return _napisVisibility; }
            set
            {
                _napisVisibility = value;
                OnPropertyChanged(nameof(NapisVisibility)); 
            }
        }

        public Visibility Napis2Visibility
        {
            get { return _napis2Visibility; }
            set
            {
                _napis2Visibility = value;
                OnPropertyChanged(nameof(Napis2Visibility));
            }
        }


        private Visibility _rozpocznijVisibility;
        private Visibility _stopVisibility;
        private Visibility _zakonczVisibility;
        private Visibility _startVisibility;

        private Visibility _pompkiVisibility;
        private Visibility _przysiadyVisibility;
        private Visibility _brzuszkiVisibility;
        private Visibility _plankVisibility;

        private Visibility _czasVisibility;
        private Visibility _napisVisibility;
        private Visibility _napis2Visibility;

        public Visibility RozpocznijVisibility 
        {
            get { return _rozpocznijVisibility; }
            set
            {
                _rozpocznijVisibility = value;
                OnPropertyChanged(nameof(RozpocznijVisibility)); 
            }
        }

        public Visibility StopVisibility 
        {
            get { return _stopVisibility; }
            set
            {
                _stopVisibility = value;
                OnPropertyChanged(nameof(StopVisibility));
            }

        }

        public Visibility ZakonczVisibility 
        {
            get { return _zakonczVisibility; }
            set
            {
                _zakonczVisibility = value;
                OnPropertyChanged(nameof(ZakonczVisibility)); 
            }

        }

        public Visibility PompkiVisibility 
        {
            get { return _pompkiVisibility; }
            set
            {
                _pompkiVisibility = value;
                OnPropertyChanged(nameof(PompkiVisibility)); 
            }

        }

        public Visibility PrzysiadyVisibility 
        {
            get { return _przysiadyVisibility; }
            set
            {
                _przysiadyVisibility = value;
                OnPropertyChanged(nameof(PrzysiadyVisibility));
            }

        }

        public Visibility BrzuszkiVisibility
        {
            get { return _brzuszkiVisibility; }
            set
            {
                _brzuszkiVisibility = value;
                OnPropertyChanged(nameof(BrzuszkiVisibility));
            }

        }

        public Visibility PlankVisibility
        {
            get { return _plankVisibility; }
            set
            {
                _plankVisibility = value;
                OnPropertyChanged(nameof(PlankVisibility));
            }

        }
        public Visibility StartVisibility
        {
            get { return _startVisibility; }
            set
            {
                _startVisibility = value;
                OnPropertyChanged(nameof(StartVisibility));
            }

        }

        public ICommand RozpocznijCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand ZakonczCommand { get; set; }
        public ICommand StartCommand { get; set; }

        public LatwyViewModels() // poczatek
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timerTick);
            time = 30;
            phase = 1;

            RozpocznijCommand = new RelayCommand(ExecuteRozpocznijCommand);
            StopCommand = new RelayCommand(ExecuteStopCommand);
            ZakonczCommand = new RelayCommand(ExecuteZakonczCommand);
            StartCommand = new RelayCommand(ExecuteStartCommand);

            StopVisibility = Visibility.Collapsed;
            ZakonczVisibility = Visibility.Collapsed;
            PompkiVisibility = Visibility.Collapsed;
            PrzysiadyVisibility = Visibility.Collapsed;
            BrzuszkiVisibility = Visibility.Collapsed;
            PlankVisibility = Visibility.Collapsed;
            NapisVisibility = Visibility.Collapsed;
            StartVisibility = Visibility.Collapsed;
        }

        private async void ExecuteRozpocznijCommand() //Rozpocznij ONCLICK
        {
            RozpocznijVisibility = Visibility.Collapsed;
            Napis2Visibility = Visibility.Collapsed;
            StopVisibility = Visibility.Visible;
            ZakonczVisibility = Visibility.Visible;
            NapisVisibility = Visibility.Visible;
            NapisText = "Cwiczenie 1: Pompki";
            await Task.Delay(5000);
            paused = false;
            timer.Start();
            PompkiVisibility = Visibility.Visible;
        }

        private void ExecuteStopCommand() //STOP ONCLICK
        {
            paused = true;
            timer.Stop();
            StopVisibility = Visibility.Collapsed;
            StartVisibility = Visibility.Visible;
        }

        private void ExecuteZakonczCommand() //Zakoncz ONCLICK
        {
            EndTraining();
        }

        private void ExecuteStartCommand() //Start ONCLICK
        {
            paused = false;
            timer.Start();
            StartVisibility = Visibility.Collapsed;
            StopVisibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1); // ustawia na 1 sekundę
            timer.Tick += new EventHandler(timerTick);
        }

        private async void timerTick(object sender, EventArgs e)
        {
            if (!paused)
            {
                time--;

                if (time == 0)
                {
                    timer.Stop();

                    switch (phase)
                    {
                        case 1:
                            NapisVisibility = Visibility.Collapsed;
                            PompkiVisibility = Visibility.Collapsed;
                            time = 15;
                            CzasText = "Przerwa";
                            phase++;
                            break;
                        case 2:
                            NapisVisibility = Visibility.Visible;
                            CzasVisibility = Visibility.Collapsed;
                            NapisText = "Cwiczenie 2: Przysiady";
                            await Task.Delay(5000);
                            time = 30;
                            CzasVisibility = Visibility.Visible;
                            PrzysiadyVisibility = Visibility.Visible;
                            phase++;
                            break;
                        case 3:
                            NapisVisibility = Visibility.Collapsed;
                            PrzysiadyVisibility = Visibility.Collapsed;
                            CzasText = "Przerwa";
                            time = 15;
                            phase++;
                            break;
                        case 4:
                            NapisVisibility = Visibility.Visible;
                            CzasVisibility = Visibility.Collapsed;
                            NapisText = "Cwiczenie 3: Brzuszki";
                            await Task.Delay(5000);
                            time = 30;
                            CzasVisibility = Visibility.Visible;
                            BrzuszkiVisibility = Visibility.Visible;
                            phase++;
                            break;
                        case 5:
                            NapisVisibility = Visibility.Collapsed;
                            BrzuszkiVisibility = Visibility.Collapsed;
                            CzasText = "Przerwa";
                            time = 15;
                            phase++;
                            break;
                        case 6:
                            NapisVisibility = Visibility.Visible;
                            CzasVisibility = Visibility.Collapsed;
                            NapisText = "Cwiczenie 4: Plank";
                            await Task.Delay(5000);
                            time = 30;
                            CzasVisibility = Visibility.Visible;
                            PlankVisibility = Visibility.Visible;
                            phase++;
                            break;
                        case 7:
                            EndTraining();
                            break;
                        default:
                            return;
                    }

                    timer.Start();
                }
                else
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(time);
                    CzasText = timeSpan.ToString(@"hh\:mm\:ss"); //textbox
                }
            }
        }

        private void EndTraining()
        {
            timer.Stop();
            paused = true;
            PompkiVisibility = Visibility.Collapsed;
            BrzuszkiVisibility = Visibility.Collapsed;
            PrzysiadyVisibility = Visibility.Collapsed;
            PlankVisibility = Visibility.Collapsed;
            StopVisibility = Visibility.Collapsed;
            StartVisibility = Visibility.Collapsed;
            ZakonczVisibility = Visibility.Collapsed;
            CzasVisibility = Visibility.Collapsed;
            NapisVisibility = Visibility.Visible;
            NapisText = "Koniec treningu!";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}