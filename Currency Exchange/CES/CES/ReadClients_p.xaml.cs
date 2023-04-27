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
    /// Логика взаимодействия для ReadClients_p.xaml
    /// </summary>
    public partial class ReadClients_p : Page
    {
        public ReadClients_p()
        {
            InitializeComponent();
            DGridReadClients.ItemsSource = CurrencyExchangeEntities.GetContext().Client.ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridReadClients.ItemsSource = CurrencyExchangeEntities.GetContext().Client.Where(t => t.Fullname == SearchBox.Text || t.Fullname.Contains(SearchBox.Text)
                || t.AccountNumber == SearchBox.Text || t.AccountNumber.Contains(SearchBox.Text) || t.Address == SearchBox.Text || t.Address.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
