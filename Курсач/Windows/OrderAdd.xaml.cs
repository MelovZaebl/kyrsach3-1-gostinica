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
    /// Логика взаимодействия для OrderAdd.xaml
    /// </summary>
    public partial class OrderAdd : Window
    {
        public OrdersReg Order = new OrdersReg();
        public Lodgers Lodger = new Lodgers();
        public string WorkerFIO;
        int i = 0;
        public OrderAdd(string worker)
        {
            InitializeComponent();
            CStartD.SelectedDate = DateTime.Now;
            DataContext = Order;

            WorkerFIO = worker;

            Order.OrderDate = DateTime.Now;

            CBRoom.ItemsSource = MainWindow.DB.Rooms.ToList().Where(r => r.Status == false);

            CBPol.Items.Add("Мужчина");
            CBPol.Items.Add("Женщина");
            if (Lodger.Pol == true)
            {
                CBPol.SelectedIndex = 0;
            }
            else CBPol.SelectedIndex = 1;
        }

        private void RoomChange(object sender, SelectionChangedEventArgs e)
        {
            CBGuest.Items.Clear();
            Rooms SelectedRoom = CBRoom.SelectedItem as Rooms;
            var z = MainWindow.DB.Classes.ToList().Where(p => p.ClassID == SelectedRoom.Class).First();
            for (i = 0; i < z.SpotsCount; i++)
            {
                CBGuest.Items.Add(i);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(TBFIO.Text) || TBFIO.Text.Count() > 50)
            {
                error += "Введите ФИО.\n";
            }
            if (String.IsNullOrWhiteSpace(TBPassport.Text) || TBPassport.Text.Count() > 10)
            {
                error += "Введите паспорт\n";
            }
            if (String.IsNullOrWhiteSpace(TBPhone.Text) || TBPhone.Text.Count() != 11)
            {
                error += "Введите телефон\n";
            }
            if (CStartD.SelectedDate < DateTime.Now.Subtract(new TimeSpan(1,0,0,0)))
            {
                error += "Некорректная дата заселения";
            }
            if (CStopD.SelectedDate <= CStartD.SelectedDate )
            {
                error += "Некорректная дата выселения";
            }
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (CBPol.SelectedIndex == 0)
                {
                    Lodger.Pol = true;
                }
                else if (CBPol.SelectedIndex == 1)
                {
                    Lodger.Pol = false;
                }
                else Lodger.Pol = true;

                Lodger.FIO = TBFIO.Text;
                Lodger.Passport = TBPassport.Text;
                Lodger.Phone = TBPhone.Text;
                Rooms selectedRoom = CBRoom.SelectedItem as Rooms;
                Lodger.Room = selectedRoom.Room;


                MainWindow.DB.Lodgers.Add(Lodger);
                MainWindow.DB.SaveChanges();

                Order.LodgerID = Lodger.ID;
                Order.WorkerFIO = WorkerFIO;

                if ((int)CBGuest.SelectedValue != 0)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        LodgersGuests guest = new LodgersGuests();
                        GuestUpdate win = new GuestUpdate(guest, Lodger, 1);
                        win.ShowDialog();
                    }

                    MainWindow.DB.OrdersReg.Add(Order);

                    Rooms rooma = MainWindow.DB.Rooms.ToList().Where(p => p.Room == Order.Room).First();
                    rooma.Status = true;

                    MainWindow.DB.SaveChanges();
                    this.Close();
                }
                else
                {
                    MainWindow.DB.OrdersReg.Add(Order);
                    Rooms rooma = MainWindow.DB.Rooms.ToList().Where(p => p.Room == Order.Room).First();
                    rooma.Status = true;
                    MainWindow.DB.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
