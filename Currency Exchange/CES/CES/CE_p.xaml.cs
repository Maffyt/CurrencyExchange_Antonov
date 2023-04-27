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
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;

namespace CES
{
    /// <summary>
    /// Interaction logic for CE_p.xaml
    /// </summary>
    public partial class CE_p : Page
    {
        public CE_p()
        {
            InitializeComponent();
            DGridCE.ItemsSource = CurrencyExchangeEntities.GetContext().CurrencyExchange.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCE addCE = new AddCE();
            addCE.Show();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var CEForRemoving = DGridCE.SelectedItems.Cast<CurrencyExchange>().ToList();

            if (MessageBox.Show("Are you sure?", "Warning", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CurrencyExchangeEntities.GetContext().CurrencyExchange.RemoveRange(CEForRemoving);
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
            this.DGridCE.SelectAllCells();
            this.DGridCE.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.DGridCE);
            this.DGridCE.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("Reports.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("Reports.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGridCE_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrencyExchangeEntities.GetContext().SaveChanges();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DGridCE.ItemsSource = CurrencyExchangeEntities.GetContext().CurrencyExchange.Where(t => t.QuantitySold == SearchBox.Text || t.QuantitySold.Contains(SearchBox.Text)
                || t.QuantityBought == SearchBox.Text || t.QuantityBought.Contains(SearchBox.Text)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
