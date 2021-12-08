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
            DataContext = Order;
            RoomImg.Source = new BitmapImage(new Uri(order.Rooms.Photo));
            
        }
    }
}
