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
    /// Логика взаимодействия для WorkerMainUI.xaml
    /// </summary>
    public partial class WorkerMainUI : Page
    {
        public WorkerMainUI(string AuthUser)
        {
            InitializeComponent();
            var workers = MainWindow.DB.Workers.ToList();
            var users = MainWindow.DB.Users.ToList();
            foreach (var worker in workers)
            {
                foreach(var user in users)
                if (worker.ID == user.ID && AuthUser == user.Username)
                {
                    UserFIO.Text = worker.FIO;
                }
            }
        }

        private void ShowRooms(object sender, RoutedEventArgs e)
        {
            BtnShowRooms.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#515151");
            BtnShowOrders.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowClasses.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgers.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgerGuests.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
        }

        private void ShowOrders(object sender, RoutedEventArgs e)
        {
            BtnShowRooms.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowOrders.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#515151");
            BtnShowClasses.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgers.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgerGuests.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
        }

        private void ShowLodgers(object sender, RoutedEventArgs e)
        {
            BtnShowRooms.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowOrders.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowClasses.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgers.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#515151");
            BtnShowLodgerGuests.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
        }

        private void ShowLodgerKids(object sender, RoutedEventArgs e)
        {
            BtnShowRooms.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowOrders.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowClasses.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgers.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgerGuests.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#515151");
        }

        private void ExitToAuth(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ShowClasses(object sender, RoutedEventArgs e)
        {
            BtnShowRooms.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowOrders.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowClasses.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#515151");
            BtnShowLodgers.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");
            BtnShowLodgerGuests.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#414141");

            ContentFrame.Navigate(new ClassesUI());
        }
    }
}
