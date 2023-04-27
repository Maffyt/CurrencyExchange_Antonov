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
    /// Логика взаимодействия для AdminHub.xaml
    /// </summary>
    public partial class AdminHub : Window
    {
        public AdminHub()
        {
            InitializeComponent();
        }
        // кнопки для переключения между страницами
        // переход на страницу с аккаунтами
        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new User_p();
        }

        // переход на страницу с клиентами
        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Clients_p();
        }

        // переход на страницу с сотрудниками
        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Employees_p();
        }

        // переход на страницу с валютами
        private void BtnCurrency_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Content = new Currency_p();
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
