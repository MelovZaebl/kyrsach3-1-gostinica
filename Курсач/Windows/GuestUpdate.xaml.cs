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
    /// Логика взаимодействия для GuestUpdate.xaml
    /// </summary>
    public partial class GuestUpdate : Window
    {
        private LodgersGuests Guest;
        public GuestUpdate(LodgersGuests guest)
        {
            InitializeComponent();
            this.Guest = guest;
            DataContext = guest;
            CBPol.Items.Add("Мужчина");
            CBPol.Items.Add("Женщина");
            if (Guest.Pol == true)
            {
                CBPol.SelectedIndex = 0;
            }
            else CBPol.SelectedIndex = 1;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(Guest.FIO) || Guest.FIO.Count() > 50)
            {
                error += "Введите ФИО\n";
            }
            if (String.IsNullOrWhiteSpace(Guest.Passport.ToString()) || Guest.Passport.ToString().Count() != 10)
            {
                error += "Введите паспорт.\n";
            }
            if (String.IsNullOrWhiteSpace(Guest.Phone.ToString()))
            {
                error += "Введите телефон.\n";
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
                    Guest.Pol = true;
                }
                else if (CBPol.SelectedIndex == 1)
                {
                    Guest.Pol = false;
                }
                else Guest.Pol = true;
                MainWindow.DB.SaveChanges();
                this.Close();
            }
        }
    }
}
