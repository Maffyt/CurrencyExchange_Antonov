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
    /// Логика взаимодействия для ReadCurrency_p.xaml
    /// </summary>
    public partial class ReadCurrency_p : Page
    {
        public ReadCurrency_p()
        {
            InitializeComponent();
            DGridReadCurrency.ItemsSource = CurrencyExchangeEntities.GetContext().Currency.ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridReadCurrency.ItemsSource = CurrencyExchangeEntities.GetContext().Currency.Where(t => t.Name == SearchBox.Text || t.Name.Contains(SearchBox.Text)
                || t.Quantity == SearchBox.Text || t.Quantity.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
