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
        public RoomUI()
        {
            InitializeComponent();
            RoomView.Items.Clear();
            UpdateRooms();
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
                Windows.RoomUpdate win = new Windows.RoomUpdate(room, 1);
                win.ShowDialog();
                UpdateRooms();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Rooms room = RoomView.SelectedItem as Rooms;
            MainWindow.DB.Rooms.Remove(room);
        }
    }
}
