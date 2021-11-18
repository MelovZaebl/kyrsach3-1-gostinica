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

namespace Курсач.Windows
{
    /// <summary>
    /// Логика взаимодействия для UsersUpdate.xaml
    /// </summary>
    public partial class UsersUpdate : Window
    {

        private Users User;
        public UsersUpdate(Users user, int style)
        {
            InitializeComponent();
            this.User = user;
            DataContext = user;
            if(style == 1)
            {
                btnSave.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Hidden;
            }
            else if (style == 2)
            {
                btnSave.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Visible;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(User.Username))
            {
                error += "Введите имя пользователя.\n";
            }
            if (String.IsNullOrWhiteSpace(User.Password))
            {
                error += "Введите пароль.\n";
            }
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {

                MainWindow.DB.Users.Add(User);
                MainWindow.DB.SaveChanges();
                this.Close();
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
