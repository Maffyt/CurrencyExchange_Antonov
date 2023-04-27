using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Clients_p.xaml
    /// </summary>
    public partial class Clients_p : Page
    {
        public Clients_p()
        {
            InitializeComponent();
            DGridClients.ItemsSource = CurrencyExchangeEntities.GetContext().Client.ToList();
        }

        // Добавление записи
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();
        }

        // удаление записи
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var CurrencyForRemoving = DGridClients.SelectedItems.Cast<Currency>().ToList();

            if (MessageBox.Show("Are you sure?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CurrencyExchangeEntities.GetContext().Currency.RemoveRange(CurrencyForRemoving);
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
            this.DGridClients.SelectAllCells();
            this.DGridClients.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.DGridClients);
            this.DGridClients.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("Clients.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("Clients.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGridClients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrencyExchangeEntities.GetContext().SaveChanges();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridClients.ItemsSource = CurrencyExchangeEntities.GetContext().Client.Where(t => t.Fullname == SearchBox.Text || t.Fullname.Contains(SearchBox.Text)
                || t.AccountNumber == SearchBox.Text || t.AccountNumber.Contains(SearchBox.Text) || t.Address == SearchBox.Text || t.Address.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
