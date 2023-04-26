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

namespace Aplikacja_do_treningu
{
    /// <summary>
    /// Logika interakcji dla klasy Silowy.xaml
    /// </summary>
    public partial class Silowy : Window
    {
        public Silowy()
        {
            InitializeComponent();
        }

        private void silowy_latwy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Utwórz nowe okno i otwórz je.
            silowy_latwy Silowy2 = new silowy_latwy();
            Silowy2.Show();

            // Ukryj okno główne.
            this.Hide();
        }

        private void silowy_normalny_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Utwórz nowe okno i otwórz je.
            silowy_normalny Silowy3 = new silowy_normalny();
            Silowy3.Show();

            // Ukryj okno główne.
            this.Hide();
        }

        private void silowy_trudny_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Utwórz nowe okno i otwórz je.
            silowy_trudny Silowy4 = new silowy_trudny();
            Silowy4.Show();

            // Ukryj okno główne.
            this.Hide();
        }
    }
}