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

namespace CES
{
    /// <summary>
    /// Логика взаимодействия для ReadEmployees_p.xaml
    /// </summary>
    public partial class ReadEmployees_p : Page
    {
        public ReadEmployees_p()
        {
            InitializeComponent();
            DGridReadEmployees.ItemsSource = CurrencyExchangeEntities.GetContext().Employee.ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridReadEmployees.ItemsSource = CurrencyExchangeEntities.GetContext().Employee.Where(t => t.FullName == SearchBox.Text || t.FullName.Contains(SearchBox.Text)
                || t.Post == SearchBox.Text || t.Post.Contains(SearchBox.Text) || t.Address == SearchBox.Text || t.Address.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
