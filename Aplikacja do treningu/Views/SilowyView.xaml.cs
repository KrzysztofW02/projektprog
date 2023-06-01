using Aplikacja_do_treningu.ViewModels;
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

namespace Aplikacja_do_treningu.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SilowyView.xaml
    /// </summary>
    public partial class SilowyView : Window
    {
        public SilowyView()
        {
            InitializeComponent();
            DataContext = new SilowyViewModel();
        }
    }
}
