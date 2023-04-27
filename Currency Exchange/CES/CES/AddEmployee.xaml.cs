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
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private Employee _currentEmployee = new Employee();
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = _currentEmployee;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentEmployee.Id == 0)
                CurrencyExchangeEntities.GetContext().Employee.Add(_currentEmployee);

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
