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
using System.Collections.ObjectModel; // ObservableCollection
using System.ComponentModel; // CancelEventArgs
using System.Runtime.CompilerServices; // CallerMemberName
using Lj2Dd1En2.Models;

namespace Lj2Dd1En2.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Fields
        private readonly LosPollosHermanosDB db = new LosPollosHermanosDB();
        private readonly string serviceDeskBericht = "\n\n Neem contact op met de service desk";
        #endregion
        #region Properties
        private ObservableCollection<Meal> _meals = new();
        public ObservableCollection<Meal> Meals
        {
            get { return _meals; }
            set { _meals = value; OnPropertyChanged(); }
        }

        private Meal? _selectedMeal = new();
        public Meal? SelectedMeal
        {
            get { return _selectedMeal; }
            set { _selectedMeal = value; OnPropertyChanged(); }
        }
        #endregion
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
            PopulateMeals();
        }

        private void PopulateMeals()
        {
            string dbResult = db.Getmeals(Meals);
            if (dbResult != LosPollosHermanosDB.OK)
            {
                MessageBox.Show(dbResult + serviceDeskBericht);
            }
        }
    }
}
