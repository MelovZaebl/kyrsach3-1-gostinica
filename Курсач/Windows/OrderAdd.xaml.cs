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

            //CBRoom.ItemsSource = MainWindow.DB.Rooms.ToList().Where(r => r.Status == false); Можно регу только на свободные комнаты
            CBRoom.ItemsSource = MainWindow.DB.Rooms.ToList();

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
            Rooms selectedRoom = CBRoom.SelectedItem as Rooms;
            Order.Room = selectedRoom.ID;
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(TBFIO.Text) || TBFIO.Text.Count() > 50)
            {
                error += "Введите ФИО.\n";
            }
            if (String.IsNullOrWhiteSpace(TBPassport.Text) || TBPassport.Text.Count() != 10)
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
            int RoomCheck = 0;
            foreach (OrdersReg RoomOrder in MainWindow.DB.OrdersReg.ToList().Where(o => o.Room == Order.Room))
            {
                if (Order.StartDate.CompareTo(RoomOrder.StartDate) < 0 && Order.StopDate.CompareTo(RoomOrder.StartDate) < 0);
                else if (Order.StartDate.CompareTo(RoomOrder.StopDate) > 0);
                else RoomCheck++;
            }
            if (RoomCheck != 0) error += "На эти даты уже есть бронь";

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
                Lodger.Room = selectedRoom.Room;


                MainWindow.DB.Lodgers.Add(Lodger);
                MainWindow.DB.SaveChanges();

                Order.LodgerID = Lodger.ID;
                Order.WorkerFIO = WorkerFIO;

                //decimal Price = 0;
                //var z = MainWindow.DB.Rooms.ToList().Where(r => r.ID == Order.Room).First();
                //for (int i = 0; i <= (Order.StopDate.Date - Order.StartDate.Date).Days; i++)
                //{
                //    Price += z.Classes.DailyPrice;
                //}
                //TPrice.Text = Price.ToString("c0");
                //MessageBox.Show($"Сумма к оплате: {Price.ToString("c0")}", "Сумма к оплате", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None); // попробовать сделать через вычисляемое поле
                if ((int)CBGuest.SelectedValue != 0)
                {
                    for (int j = 1; j < i; j++)
                    {
                        LodgersGuests guest = new LodgersGuests();
                        GuestUpdate win1 = new GuestUpdate(guest, Lodger, 1);
                        win1.ShowDialog();
                    }

                    MainWindow.DB.OrdersReg.Add(Order);

                    if (DateTime.Compare(DateTime.Today, Order.StartDate) < 0) Order.Rooms.Status = false;
                    else if (DateTime.Compare(DateTime.Today, Order.StopDate) > 0) Order.Rooms.Status = false;
                    else Order.Rooms.Status = true;

                    MainWindow.DB.SaveChanges();
                    Check win2 = new Check(WorkerFIO, Order);
                    win2.ShowDialog();
                    this.Close();
                }
                else
                {
                    MainWindow.DB.OrdersReg.Add(Order);
                    Rooms rooma = MainWindow.DB.Rooms.ToList().Where(p => p.ID == Order.Room).First();
                    rooma.Status = true;
                    MainWindow.DB.SaveChanges();
                    Check win2 = new Check(WorkerFIO, Order);
                    win2.ShowDialog();
                    this.Close();
                    
                }
            }
        }

        private void FIOInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void PassportInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void PhoneInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
