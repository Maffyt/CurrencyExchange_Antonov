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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private Client _currentClient = new Client();
        public AddClient()
        {
            InitializeComponent();
            DataContext = _currentClient;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.AccountNumber))
                Errors.AppendLine("Please, enter account number!");
            if (string.IsNullOrWhiteSpace(_currentClient.Fullname))
                Errors.AppendLine("Please, enter full name!");
            if (_currentClient.DateOfBirth == null)
                Errors.AppendLine("Please, enter birthday!");
            if (string.IsNullOrWhiteSpace(_currentClient.Passport))
                Errors.AppendLine("Please, enter serial and number of passport!");
            if (string.IsNullOrWhiteSpace(_currentClient.NumberPhone))
                Errors.AppendLine("Please, enter number phone!о");
            if (string.IsNullOrWhiteSpace(_currentClient.Address))
                Errors.AppendLine("Please, enter address!");

            if (_currentClient.Id == 0)
                CurrencyExchangeEntities.GetContext().Client.Add(_currentClient);

            try
            {
                CurrencyExchangeEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved!");
                Close();
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
