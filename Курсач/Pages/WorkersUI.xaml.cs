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
            WorkersTable.ItemsSource = MainWindow.DB.Workers.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            int style = 1;
            Workers worker = new Workers();
            Windows.WorkersUpdate win = new Windows.WorkersUpdate(worker, style);
            win.ShowDialog();
            UpdateAgents();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            int style = 2;
            Workers worker = new Workers();
            int i = 0;
            foreach (var workera in MainWindow.DB.Workers.ToList())
            {
                if (WorkersTable.SelectedIndex == i)
                {
                    worker = workera;
                    break;
                }
                i++;
            }
            Windows.WorkersUpdate win = new Windows.WorkersUpdate(worker, style);
            win.ShowDialog();
            UpdateAgents();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var deletedWorker = WorkersTable.SelectedItem as Workers;
            if (deletedWorker != null)
            {
                if (deletedWorker.ID == 1)
                {
                    MessageBox.Show("Вы не можете удалить данного работника!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    foreach (var user in MainWindow.DB.Users.ToList())
                    {
                        if (deletedWorker.ID == user.ID)
                        {
                            MainWindow.DB.Users.Remove(user);
                            break;
                        }
                    }
                    MainWindow.DB.Workers.Remove(deletedWorker);
                    MainWindow.DB.SaveChanges();
                    UpdateAgents();
                }
            }
            else MessageBox.Show("Выберите запись для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
