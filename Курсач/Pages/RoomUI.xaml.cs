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
    /// Логика взаимодействия для RoomUI.xaml
    /// </summary>
    public partial class RoomUI : Page
    {
        public RoomUI(int style)
        {
            InitializeComponent();
            RoomView.Items.Clear();
            UpdateRooms();

            foreach (OrdersReg Order in MainWindow.DB.OrdersReg)
            {
                if (DateTime.Compare(DateTime.Today, Order.StartDate) < 0) Order.Rooms.Status = false;
                else if (DateTime.Compare(DateTime.Today, Order.StopDate) > 0) Order.Rooms.Status = false;
                else Order.Rooms.Status = true;
            }

            if (style == 1)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
        }

        private void UpdateRooms()
        {
            RoomView.Items.Clear();
            foreach (var rooma in MainWindow.DB.Rooms.ToList())
            {
                RoomView.Items.Add(rooma);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Rooms room = new Rooms();
            Windows.RoomUpdate win = new Windows.RoomUpdate(room, 0);
            win.ShowDialog();
            UpdateRooms();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            if (RoomView.SelectedItem == null) MessageBox.Show("Выберите запись для редактирования!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                Rooms room = RoomView.SelectedItem as Rooms;
                int i = 0;
                foreach(OrdersReg RoomOrder in MainWindow.DB.OrdersReg.ToList())
                {
                    if(RoomOrder.Room == room.ID) i++;
                }
                if (i == 0)
                {
                    Windows.RoomUpdate win = new Windows.RoomUpdate(room, 1);
                    win.ShowDialog();
                    UpdateRooms();
                }
                else MessageBox.Show("На данную комнату есть активная бронь!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Rooms room = RoomView.SelectedItem as Rooms;
            if (room.Status == false)
            {
                MainWindow.DB.Rooms.Remove(room);
                MainWindow.DB.SaveChanges();
                UpdateRooms();
            }
            else MessageBox.Show("Удаление невозможно, в комнате кто-то живет.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
