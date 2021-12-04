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

        }
    }
}
