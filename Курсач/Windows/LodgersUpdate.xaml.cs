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
    /// Логика взаимодействия для LodgersUpdate.xaml
    /// </summary>
    public partial class LodgersUpdate : Window
    {
        private Lodgers Lodger;
        public LodgersUpdate(Lodgers lodger)
        {
            InitializeComponent();
            this.Lodger = lodger;
            DataContext = lodger;
            CBPol.Items.Add("Мужчина");
            CBPol.Items.Add("Женщина");
            if (Lodger.Pol == true)
            {
                CBPol.SelectedIndex = 0;
            }
            else CBPol.SelectedIndex = 1;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(Lodger.FIO) || Lodger.FIO.Count() > 50)
            {
                error += "Введите ФИО\n";
            }
            if (String.IsNullOrWhiteSpace(Lodger.Passport.ToString()) || Lodger.Passport.ToString().Count() != 10)
            {
                error += "Введите паспорт.\n";
            }
            if (String.IsNullOrWhiteSpace(Lodger.Room.ToString()))
            {
                error += "Введите номер комнаты.\n";
            }
            if (String.IsNullOrWhiteSpace(Lodger.Phone.ToString()) || Lodger.Phone.Count() != 11)
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
                    Lodger.Pol = true;
                }
                else if (CBPol.SelectedIndex == 1)
                {
                    Lodger.Pol = false;
                }
                else Lodger.Pol = true;
                MainWindow.DB.SaveChanges();
                this.Close();
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
