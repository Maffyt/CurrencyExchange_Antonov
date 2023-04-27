using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Currency_p.xaml
    /// </summary>
    public partial class Currency_p : Page
    {
        public Currency_p()
        {
            InitializeComponent();
            DGridCurrency.ItemsSource = CurrencyExchangeEntities.GetContext().Currency.ToList();

            UpdateCurrency();
        }
        // кнопка открытия окна редактирования
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCurrency addCurrency = new AddCurrency();
            addCurrency.Show();
        }

        // кнопка удаления записи
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var CurrencyForRemoving = DGridCurrency.SelectedItems.Cast<Currency>().ToList();

            if (MessageBox.Show("Are you sure?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CurrencyExchangeEntities.GetContext().Currency.RemoveRange(CurrencyForRemoving);
                    CurrencyExchangeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Data Deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // кнопка экспорта
        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            this.DGridCurrency.SelectAllCells();
            this.DGridCurrency.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.DGridCurrency);
            this.DGridCurrency.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("Currencies.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("Currencies.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGridCurrency_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrencyExchangeEntities.GetContext().SaveChanges();
        }

        private void UpdateCurrency()
        {
            var currentCurrency = CurrencyExchangeEntities.GetContext().Currency.ToList();

            currentCurrency = currentCurrency.Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower())).ToList();

            
        }

        // Seach
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridCurrency.ItemsSource = CurrencyExchangeEntities.GetContext().Currency.Where(t => t.Name == SearchBox.Text || t.Name.Contains(SearchBox.Text) 
                || t.Quantity == SearchBox.Text || t.Quantity.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
