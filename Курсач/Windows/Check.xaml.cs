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
using System.Windows.Shapes;

namespace Курсач.Windows
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        public Check(string worker, OrdersReg Order)
        {
            InitializeComponent();
            DataContext = Order;
            TWorker.Text = worker;
            decimal Price = 0;
            var z = MainWindow.DB.Rooms.ToList().Where(r => r.ID == Order.Room).First();
            for (int i = 0; i <= (Order.StopDate.Date - Order.StartDate.Date).Days; i++)
            {
                Price += z.Classes.DailyPrice;
            }
            TPrice.Text = Price.ToString("c0");
        }
    }
}
