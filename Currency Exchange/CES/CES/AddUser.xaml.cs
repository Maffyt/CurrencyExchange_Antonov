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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private User _currentUser = new User();
        public AddUser()
        {
            InitializeComponent();
            DataContext = _currentUser;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Id == 0)
                CurrencyExchangeEntities.GetContext().User.Add(_currentUser);

            try
            {
                CurrencyExchangeEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
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
