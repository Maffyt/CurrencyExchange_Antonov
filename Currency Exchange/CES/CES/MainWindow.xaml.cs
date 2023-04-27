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
using System.Windows.Threading;

namespace CES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Pass.IsEnabled = true;
            Code.IsEnabled = true;
            Log.Focus();
            Refresh.IsEnabled = true;
            Enter.IsEnabled = true;
        }
        // Логин
        private void Log_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (var db = new CurrencyExchangeEntities())
                {
                    var number = db.User.AsNoTracking().FirstOrDefault(m => m.Login ==
                    Log.Text.Trim());

                    if (number == null)
                    {
                        MessageBox.Show("Неверный логин");
                    }
                    else
                    {
                        Pass.Focus();
                    }
                }
            }
        }

        // Пароль
        private void Pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (var db = new CurrencyExchangeEntities())
                {
                    var passw = db.User.AsNoTracking().FirstOrDefault(m => m.Login ==
            Log.Text.Trim() & (m.Password == Pass.Password));

                    if (passw == null)
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                    else
                    {
                        gencode();
                        Code.Focus();
                    }
                }
            }
        }


        // Случайный генератор кода с таймеров на 10 секунд
        DispatcherTimer timer = new DispatcherTimer();
        string code;

        private void gencode()
        {
            code = null;
            Random random = new Random();
            string[] massiveCharacters = new string[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"
            };

            // цикл подбора цифр (4 цифры)

            for (int i = 0; i < 4; i++)
                code += massiveCharacters[random.Next(0, massiveCharacters.Length)];
            if (MessageBox.Show(code.ToString(), "Code", MessageBoxButton.OK, 
                MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        // сообщение о сбросе кода
        void Timer_Tick(object sender, EventArgs e)
        {
            code = null;
            MessageBox.Show("Код сброшен");
            timer.Stop();
        }

        // кнопка получения кода
        private void Refresh_Click(object sender, EventArgs e)
        {
            timer.Stop();
            gencode();
            Code.Focus();
        }

        // обработчик событий кнопки входа
        private void Enter_Click(object sender, EventArgs e)
        {
            if (code == Code.Text)
            {
                timer.Stop();
                using (var db = new CurrencyExchangeEntities())
                {

                    // проверка корректности данных

                    var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == Log.Text && u.Password == 
                    Pass.Password);

                    // определение роли

                    if (user.AdminStatus == true)
                    {
                        AdminHub adminHub = new AdminHub();
                        adminHub.Show();
                        Application.Current.MainWindow.Close();
                    }
                    else
                    {
                        EmpHub empHub = new EmpHub();
                        empHub.Show();
                        Application.Current.MainWindow.Close();
                    }
                }
            }
            else
            {
                // сообщение, в случае неккоректности веденных данных

                timer.Stop();
                MessageBox.Show("Ошибка данных");
            }
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
