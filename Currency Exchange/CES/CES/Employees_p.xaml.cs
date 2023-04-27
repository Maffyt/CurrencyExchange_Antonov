using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Employees_p.xaml
    /// </summary>
    public partial class Employees_p : Page
    {
        public Employees_p()
        {
            InitializeComponent();
            DGridEmployees.ItemsSource = CurrencyExchangeEntities.GetContext().Employee.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeForRemoving = DGridEmployees.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show("Are you sure?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CurrencyExchangeEntities.GetContext().Employee.RemoveRange(EmployeeForRemoving);
                    CurrencyExchangeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            this.DGridEmployees.SelectAllCells();
            this.DGridEmployees.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.DGridEmployees);
            this.DGridEmployees.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("Employees.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("Employees.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGridEmployees_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrencyExchangeEntities.GetContext().SaveChanges();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridEmployees.ItemsSource = CurrencyExchangeEntities.GetContext().Employee.Where(t => t.FullName == SearchBox.Text || t.FullName.Contains(SearchBox.Text)
                || t.Post == SearchBox.Text || t.Post.Contains(SearchBox.Text) || t.Address == SearchBox.Text || t.Address.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
