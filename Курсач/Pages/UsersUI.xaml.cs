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
            UsersTable.ItemsSource = MainWindow.DB.Users.ToList();
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

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
