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

namespace Курсач.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersUI.xaml
    /// </summary>
    public partial class UsersUI : Page
    {
        public UsersUI()
        {
            InitializeComponent();
            UsersTable.Items.Clear();
            UpdateAgents();
        }

        private void UpdateAgents()
        {
            UsersTable.ItemsSource = null;
            UsersTable.ItemsSource = MainWindow.DB.Users.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            int style = 1;
            Users user = new Users();
            Windows.UsersUpdate win = new Windows.UsersUpdate(user, style);
            win.ShowDialog();
            UpdateAgents();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            int style = 2;
            Users user = new Users();
            int i = 0;
            foreach (var usera in MainWindow.DB.Users.ToList())
            {
                if(UsersTable.SelectedIndex == i)
                {
                    user = usera;
                    break;
                }
                i++;
            }
            Windows.UsersUpdate win = new Windows.UsersUpdate(user, style);
            win.ShowDialog();
            UpdateAgents();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var deletedUser = UsersTable.SelectedItem as Users;
            if (deletedUser != null)
            {
                if (deletedUser.ID == 1)
                {
                    MessageBox.Show("Вы не можете удалить данного пользователя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MainWindow.DB.Users.Remove(deletedUser);
                    MainWindow.DB.SaveChanges();
                    UpdateAgents();
                }
            }
            else MessageBox.Show("Выберите запись для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
