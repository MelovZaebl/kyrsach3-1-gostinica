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

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static string AuthUser;
        public Authorization()
        {
            InitializeComponent();
        }

        private void ShowPass(object sender, RoutedEventArgs e)
        {
            PasswordVisible.Text = PasswordHidden.Password;
            PasswordVisible.Visibility = Visibility.Visible;
        }

        private void HidePass(object sender, RoutedEventArgs e)
        {
            PasswordHidden.Password = PasswordVisible.Text;
            PasswordVisible.Visibility = Visibility.Hidden;
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            int loginCheck = 0;
            var users = MainWindow.DB.Users.ToList();
            if (CBPass.IsChecked == true)
            {
                foreach (var user in users)
                {
                    loginCheck = 0;
                    if (user.Username == LoginBox.Text && user.Password == PasswordVisible.Text)
                    {
                        AuthUser = user.Workers.FIO;
                        foreach(var worker in MainWindow.DB.Workers.ToList())
                        {
                            if (worker.ID == user.ID)
                            {
                                if (worker.Doljnost == "Администратор приложения")
                                {
                                    NavigationService.Navigate(new Pages.MainUI(AuthUser));
                                    break;
                                }
                                else
                                {
                                    NavigationService.Navigate(new Pages.WorkerMainUI(AuthUser));
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    else loginCheck++;
                }
            }
            else
            {
                foreach (var user in users)
                {
                    loginCheck = 0;
                    if (user.Username == LoginBox.Text && user.Password == PasswordHidden.Password)
                    {
                        AuthUser = user.Workers.FIO;
                        foreach (var worker in MainWindow.DB.Workers.ToList())
                        {
                            if (worker.ID == user.ID)
                            {
                                if (worker.Doljnost == "Администратор приложения")
                                {
                                    NavigationService.Navigate(new Pages.MainUI(AuthUser));
                                    break;
                                }
                                else
                                {
                                    NavigationService.Navigate(new Pages.WorkerMainUI(AuthUser));
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    else loginCheck++;
                }
            }
            if (loginCheck > 0) MessageBox.Show("Неправильный логин или пароль");
            LoginBox.Text = "";
            PasswordHidden.Password = "";
            PasswordVisible.Text = "";
        }
    }
}
