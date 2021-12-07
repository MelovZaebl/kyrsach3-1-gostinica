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
    /// Логика взаимодействия для OrderUI.xaml
    /// </summary>
    public partial class OrderUI : Page
    {
        public string worker;
        public OrderUI(string AuthUser)
        {
            InitializeComponent();
            worker = AuthUser;
            OrdersTable.Items.Clear();
            UpdateOrders();

            foreach (OrdersReg Order in MainWindow.DB.OrdersReg)
            {
                if (DateTime.Compare(DateTime.Today, Order.StartDate) < 0) Order.Rooms.Status = false;
                else if (DateTime.Compare(DateTime.Today, Order.StopDate) > 0) Order.Rooms.Status = false;
                else Order.Rooms.Status = true;
            }
        }
        private void UpdateOrders()
        {
            OrdersTable.Items.Clear();
            foreach (var ordera in MainWindow.DB.OrdersReg.ToList())
            {
                OrdersTable.Items.Add(ordera);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Windows.OrderAdd win = new Windows.OrderAdd(worker);
            win.ShowDialog();
            UpdateOrders();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (OrdersTable.SelectedItem != null)
            {
                if (MessageBox.Show("Подтвердите удаление!", "Подтвердите удаление!", MessageBoxButton.OKCancel, MessageBoxImage.None) == MessageBoxResult.OK)
                {
                    OrdersReg deletedOrder = OrdersTable.SelectedItem as OrdersReg;
                    List<LodgersGuests> guestToDelete = new List<LodgersGuests>();
                    foreach (LodgersGuests deletedGuest in deletedOrder.Lodgers.LodgersGuests)
                    {
                        guestToDelete.Add(deletedGuest);
                        //MainWindow.DB.LodgersGuests.Remove(deletedGuest);
                    }
                    foreach(LodgersGuests deletedGuest in guestToDelete)
                    {
                        MainWindow.DB.LodgersGuests.Remove(deletedGuest);
                    }
                    MainWindow.DB.Lodgers.Remove(deletedOrder.Lodgers);
                    MainWindow.DB.OrdersReg.Remove(deletedOrder);
                    Rooms deletedRoom = MainWindow.DB.Rooms.Where(r => r.ID == deletedOrder.Room).First();
                    deletedRoom.Status = false;
                    //deletedOrder.Rooms.Status = false;
                    MainWindow.DB.SaveChanges();
                }
            }
            else MessageBox.Show("Выберите заказ для удаления!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            UpdateOrders();
        }
    }
}
