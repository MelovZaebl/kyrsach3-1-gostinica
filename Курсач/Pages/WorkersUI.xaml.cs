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
    /// Логика взаимодействия для WorkersUI.xaml
    /// </summary>
    public partial class WorkersUI : Page
    {
        public WorkersUI()
        {
            InitializeComponent();
            WorkersTable.Items.Clear();
            UpdateAgents();
        }

        private void UpdateAgents()
        {
            WorkersTable.ItemsSource = null;
            WorkersTable.ItemsSource = MainWindow.DB.Users.ToList();
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
