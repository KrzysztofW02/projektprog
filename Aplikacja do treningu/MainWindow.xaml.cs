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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikacja_do_treningu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Utwórz nowe okno i otwórz je.
            Silowy Silowy1 = new Silowy();
            Silowy1.Show();

            // Ukryj okno główne.
            this.Hide();
        }
    }
}
