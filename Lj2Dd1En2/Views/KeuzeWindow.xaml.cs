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
namespace Lj2Dd1En2.Views
{
    /// <summary>
    /// Interaction logic for KeuzeWindow.xaml
    /// </summary>
    public partial class KeuzeWindow : Window
    {
        Window1 mainView = new Window1();
        public KeuzeWindow()
        {
            InitializeComponent();
        }

        private void btMaaltijden_Click(object sender, RoutedEventArgs e)
        {
            showMaaltijden();
        }

        private void btMaaltijden2_Click(object sender, RoutedEventArgs e)
        {
            showMaaltijden();
        }

        private void btIngredienten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showMaaltijden()
        {
            mainView.Show();
            this.Close();   
        }
    }
}
