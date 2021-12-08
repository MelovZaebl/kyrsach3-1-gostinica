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
    /// Логика взаимодействия для OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Page
    {
        public OrdersReg order;
        public OrderInfo(OrdersReg Order)
        {
            InitializeComponent();
            order = Order;
            DataContext = order;
            RoomImg.Source = new BitmapImage(new Uri(order.Rooms.Photo));

            TBNum.Text = $"Номер комнаты: {order.Rooms.Room}";
            TBClass.Text = $"Класс: {order.Rooms.Classes.ClassName}";
            TBStartDate.Text = $"Дата заселения: {order.StartDate.Day}.{order.StartDate.Month}.{order.StartDate.Year}";
            TBStopDate.Text = $"Дата выселения: {order.StopDate.Day}.{order.StopDate.Month}.{order.StopDate.Year}";
            TBDailyPrice.Text = $"Цена в сутки: {order.Rooms.Classes.DailyPrice.ToString("c0")}";
            decimal Price = 0;
            var z = MainWindow.DB.Rooms.ToList().Where(r => r.ID == order.Room).First();
            for (int i = order.StartDate.Day; i <= order.StopDate.Day; i++)
            {
                Price += z.Classes.DailyPrice;
            }
            TBTotalPrice.Text = $"Стоимость проживания: {Price.ToString("c0")}";

            LodgerFIO.Text = $"ФИО: {order.Lodgers.FIO}";
            LodgerPassport.Text = $"Паспорт: {order.Lodgers.Passport}";
            LodgerPhone.Text = $"Телефон: {order.Lodgers.Phone}";
            LodgerPolText.Text = $"Пол: {order.Lodgers.PolText}";

            GuestTable.ItemsSource = order.Lodgers.LodgersGuests;
        }
    }
}
