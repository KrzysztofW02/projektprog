﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Aplikacja_do_treningu
{
    /// <summary>
    /// Logika interakcji dla klasy silowy_latwy.xaml
    /// </summary>
    /// 
    public partial class silowy_trudny : Window
    {
        private DispatcherTimer _timer;
        private int _time;
        private int _stage;
        private bool _paused;

        public silowy_trudny()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(timerTick);
            _time = 120;
            _stage = 1;
            STOP.Visibility = Visibility.Collapsed;
            Zakoncz.Visibility = Visibility.Collapsed;
            START.Visibility = Visibility.Collapsed;
            pompkigif.Visibility = Visibility.Collapsed;
            przysiadygif.Visibility = Visibility.Collapsed;
            brzuszkigif.Visibility = Visibility.Collapsed;
            plank.Visibility = Visibility.Collapsed;
            Napis_latwy.Visibility = Visibility.Collapsed;
        }

        private async void Rozpocznij_Click(object sender, RoutedEventArgs e)
        {
            rozpocznij_latwy.Visibility = Visibility.Collapsed;
            STOP.Visibility = Visibility.Visible;
            Zakoncz.Visibility = Visibility.Visible;
            Napis_latwy.Visibility = Visibility.Visible;
            await Task.Delay(5000);
            Napis_latwy.Visibility = Visibility.Collapsed;
            _paused = false;
            _timer.Start();
            pompkigif.Visibility = Visibility.Visible;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(1); // ustawia na 1 sekundę
            _timer.Tick += new EventHandler(timerTick);
        }

        private async void timerTick(object sender, EventArgs e)
        {
            if (!_paused)
            {
                _time--; 

                if (_time == 0) 
                {
                    _timer.Stop(); 

                    switch (_stage)
                    {
                        case 1:
                            pompkigif.Visibility = Visibility.Collapsed;
                            _time = 10; 
                            Czas.Text = "Przerwa"; 
                            _stage++;
                            break;
                        case 2:
                            Czas.Visibility = Visibility.Collapsed;
                            Napis_latwy.Visibility = Visibility.Visible;
                            Napis_latwy.Text = "Cwiczenie 2: Przysiady";
                            await Task.Delay(5000);
                            Napis_latwy.Visibility = Visibility.Collapsed;
                            _time = 120; 
                            Czas.Visibility = Visibility.Visible;
                            przysiadygif.Visibility = Visibility.Visible;
                            _stage++;
                            break;
                        case 3:
                            przysiadygif.Visibility = Visibility.Collapsed;
                            Czas.Text = "Przerwa";
                            _time = 10; 
                            _stage++;
                            break;
                        case 4:
                            Czas.Visibility = Visibility.Collapsed;
                            Napis_latwy.Visibility = Visibility.Visible;
                            Napis_latwy.Text = "Cwiczenie 3: Brzuszki";
                            await Task.Delay(5000);
                            Napis_latwy.Visibility = Visibility.Collapsed;
                            _time = 120; 
                            Czas.Visibility = Visibility.Visible;
                            brzuszkigif.Visibility = Visibility.Visible;
                            _stage++;
                            break;
                        case 5:
                            brzuszkigif.Visibility = Visibility.Collapsed;
                            Czas.Text = "Przerwa";
                            _time = 10; 
                            _stage++;
                            break;
                        case 6:
                            Czas.Visibility = Visibility.Collapsed;
                            Napis_latwy.Visibility = Visibility.Visible;
                            Napis_latwy.Text = "Cwiczenie 4: Plank";
                            await Task.Delay(5000);
                            Napis_latwy.Visibility = Visibility.Collapsed;
                            _time = 120; 
                            Czas.Visibility = Visibility.Visible;
                            plank.Visibility = Visibility.Visible;
                            _stage++;
                            break;
                        case 7:
                            EndTraining();
                            break;
                        default:
                            Napis_latwy.Text = "Something went not yes :>";
                            return;
                    }

                    _timer.Start(); 
                }
                else 
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(_time); 
                    Czas.Text = timeSpan.ToString(@"hh\:mm\:ss"); //textbox
                }
            }
        }

        private void Stop_Click(object sender, MouseButtonEventArgs e)
        {
            _paused = true;
            _timer.Stop(); 
            STOP.Visibility = Visibility.Collapsed;
            START.Visibility = Visibility.Visible;
        }

        private void Start_Click(object sender, MouseButtonEventArgs e)
        {
            _paused = false;
            _timer.Start();
            START.Visibility = Visibility.Collapsed;
            STOP.Visibility = Visibility.Visible;
        }

        private void Zakoncz_Click(object sender, MouseButtonEventArgs e)
        {
            EndTraining();
        }

        private void EndTraining()
        {
            _timer.Stop();
            _paused = true;
            pompkigif.Visibility = Visibility.Collapsed;
            brzuszkigif.Visibility = Visibility.Collapsed;
            przysiadygif.Visibility = Visibility.Collapsed;
            plank.Visibility = Visibility.Collapsed;
            STOP.Visibility = Visibility.Collapsed;
            START.Visibility = Visibility.Collapsed;
            Zakoncz.Visibility = Visibility.Collapsed;
            Czas.Visibility = Visibility.Collapsed;
            Napis_latwy.Visibility = Visibility.Visible;
            Napis_latwy.Text = "Koniec treningu!";
        }
    }
}
