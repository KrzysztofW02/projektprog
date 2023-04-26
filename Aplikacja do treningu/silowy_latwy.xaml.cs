using System;
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
    public partial class silowy_latwy : Window
    {
        private DispatcherTimer timer;
        private int time;
        private int phase;
        private bool paused;

        public silowy_latwy()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timerTick);
            time = 30;
            phase = 1;
            STOP.Visibility = Visibility.Collapsed;
            Zakoncz.Visibility = Visibility.Collapsed;
            START.Visibility = Visibility.Collapsed;
            pompkigif.Visibility = Visibility.Collapsed;
            przysiadygif.Visibility = Visibility.Collapsed;
            brzuszkigif.Visibility = Visibility.Collapsed;
            plank.Visibility = Visibility.Collapsed;
            Napis.Visibility = Visibility.Collapsed;
        }

        private async void Rozpocznij_Click(object sender, RoutedEventArgs e)
        {
            rozpocznij.Visibility = Visibility.Collapsed;
            STOP.Visibility = Visibility.Visible;
            Zakoncz.Visibility = Visibility.Visible;
            Napis.Visibility = Visibility.Visible;
            await Task.Delay(5000);
            Napis.Visibility = Visibility.Collapsed;
            paused = false;
            timer.Start();
            pompkigif.Visibility = Visibility.Visible;
            
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
                            pompkigif.Visibility = Visibility.Collapsed;
                            time = 15; 
                            Czas.Text = "Przerwa";
                            phase++;
                            break;
                        case 2:
                            Czas.Visibility = Visibility.Collapsed;
                            Napis.Visibility = Visibility.Visible;
                            Napis.Text = "Cwiczenie 2: Przysiady"; 
                            await Task.Delay(5000);
                            Napis.Visibility = Visibility.Collapsed;
                            time = 30;
                            Czas.Visibility = Visibility.Visible;
                            przysiadygif.Visibility = Visibility.Visible;
                            phase++;
                            break;
                        case 3:
                            przysiadygif.Visibility= Visibility.Collapsed;
                            Czas.Text = "Przerwa"; 
                            time = 15;
                            phase++;
                            break;
                        case 4:
                            Czas.Visibility = Visibility.Collapsed;
                            Napis.Visibility = Visibility.Visible;
                            Napis.Text = "Cwiczenie 3: Brzuszki"; 
                            await Task.Delay(5000);
                            Napis.Visibility = Visibility.Collapsed;
                            time = 30;
                            Czas.Visibility = Visibility.Visible;
                            brzuszkigif.Visibility = Visibility.Visible;
                            phase++;
                            break;
                        case 5:
                            brzuszkigif.Visibility = Visibility.Collapsed;
                            Czas.Text = "Przerwa";
                            time = 15;
                            phase++;
                            break;
                        case 6:
                            Czas.Visibility = Visibility.Collapsed;
                            Napis.Visibility = Visibility.Visible;
                            Napis.Text = "Cwiczenie 4: Plank";
                            await Task.Delay(5000);
                            Napis.Visibility = Visibility.Collapsed;
                            time = 30;
                            Czas.Visibility = Visibility.Visible;
                            plank.Visibility = Visibility.Visible;
                            phase++;
                            break;
                        case 7:
                            EndTraining();
                            break;
                        default:
                            Napis.Text = "Something went not yes :>";
                            return;
                    }

                    timer.Start();
                }
                else
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(time); 
                    Czas.Text = timeSpan.ToString(@"hh\:mm\:ss"); //textbox
                }
            }
        }

        private void Stop_Click(object sender, MouseButtonEventArgs e)
        {
            paused = true;
            timer.Stop(); 
            STOP.Visibility = Visibility.Collapsed;
            START.Visibility = Visibility.Visible;
        }

        private void Start_Click(object sender, MouseButtonEventArgs e)
        {
            paused = false;
            timer.Start(); 
            START.Visibility = Visibility.Collapsed;
            STOP.Visibility = Visibility.Visible;
        }

        private void Zakoncz_Click(object sender, MouseButtonEventArgs e)
        {
            EndTraining();
        }

        private void EndTraining()
        {
            timer.Stop();
            paused = true;
            pompkigif.Visibility = Visibility.Collapsed;
            brzuszkigif.Visibility = Visibility.Collapsed;
            przysiadygif.Visibility = Visibility.Collapsed;
            plank.Visibility = Visibility.Collapsed;
            STOP.Visibility = Visibility.Collapsed;
            START.Visibility = Visibility.Collapsed;
            Zakoncz.Visibility = Visibility.Collapsed;
            Czas.Visibility = Visibility.Collapsed;
            Napis.Visibility = Visibility.Visible;
            Napis.Text = "Koniec treningu!";
        }
    }
}
