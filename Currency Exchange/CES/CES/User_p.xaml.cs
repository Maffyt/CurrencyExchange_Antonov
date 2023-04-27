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
    /// Interaction logic for User_p.xaml
    /// </summary>
    public partial class User_p : Page
    {
        public User_p()
        {
            InitializeComponent();
            DGridUser.ItemsSource = CurrencyExchangeEntities.GetContext().User.ToList();
        }

        // Добавление записи

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }
        
        // удаление записи

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var UserForRemoving = DGridUser.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show("Are you sure?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CurrencyExchangeEntities.GetContext().User.RemoveRange(UserForRemoving);
                    CurrencyExchangeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // экспорт в csv

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            this.DGridUser.SelectAllCells();
            this.DGridUser.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.DGridUser);
            this.DGridUser.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("Accounts.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("Accounts.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGridUser_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrencyExchangeEntities.GetContext().SaveChanges();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridUser.ItemsSource = CurrencyExchangeEntities.GetContext().User.Where(t => t.Login == SearchBox.Text || t.Login.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
