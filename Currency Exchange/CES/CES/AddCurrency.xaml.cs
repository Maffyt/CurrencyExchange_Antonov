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

namespace CES
{
    /// <summary>
    /// Логика взаимодействия для AddCurrency.xaml
    /// </summary>
    public partial class AddCurrency : Window
    {
        private Currency _currentCurrency = new Currency();
        public AddCurrency()
        {
            InitializeComponent();
            DataContext = _currentCurrency;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCurrency.Id == 0)
                CurrencyExchangeEntities.GetContext().Currency.Add(_currentCurrency);

            try
            {
                CurrencyExchangeEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
