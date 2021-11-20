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
        private Workers Worker;
        public UsersUpdate(Users user, int style)
        {
            InitializeComponent();
            this.User = user;
            Worker = new Workers();
            DataContext = user;
            if(style == 1)
            {
                AddSP.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Hidden;
            }
            else if (style == 2)
            {
                AddSP.Visibility = Visibility.Hidden;
                btnSave.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Visible;
            }
            AddDoljnost.Items.Add("Администратор гостиницы");
            AddDoljnost.Items.Add("Администратор приложения");
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Worker.FIO = AddFIO.Text;
            Worker.Doljnost = AddDoljnost.SelectedValue.ToString();
            Worker.Phone = AddPhone.Text;

            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(User.Username) || User.Username.Count() > 50)
            {
                error += "Введите имя пользователя.\n";
            }
            if (String.IsNullOrWhiteSpace(User.Password) || User.Password.Count() > 50)
            {
                error += "Введите пароль.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.FIO) || Worker.FIO.Count() > 50)
            {
                error += "Введите ФИО.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.Doljnost) || Worker.Doljnost.Count() > 50)
            {
                error += "Введите должность.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.Phone) || Worker.Phone.Count() > 11)
            {
                error += "Введите телефон.\n";
            }
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if(Worker.ID == 0 && User.ID == 0)
                {
                    MainWindow.DB.Workers.Add(Worker);
                    MainWindow.DB.Users.Add(User);
                    MainWindow.DB.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка 404", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(User.Username) || User.Username.Count() > 50)
            {
                error += "Введите имя пользователя.\n";
            }
            if (String.IsNullOrWhiteSpace(User.Password) || User.Username.Count() > 50)
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
                MainWindow.DB.SaveChanges();
                this.Close();
            }
        }
    }
}
