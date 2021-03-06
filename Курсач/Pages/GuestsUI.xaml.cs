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
    /// Логика взаимодействия для GuestsUI.xaml
    /// </summary>
    public partial class GuestsUI : Page
    {
        public GuestsUI()
        {
            InitializeComponent();
            GuestsTable.ItemsSource = MainWindow.DB.LodgersGuests.ToList();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            LodgersGuests selectedGuest = GuestsTable.SelectedItem as LodgersGuests;
            Lodgers lodger = selectedGuest.Lodgers;
            Windows.GuestUpdate win = new Windows.GuestUpdate(selectedGuest, lodger, 0);
            win.ShowDialog();
        }
    }
}
