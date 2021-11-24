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
    /// Логика взаимодействия для LodgersUI.xaml
    /// </summary>
    public partial class LodgersUI : Page
    {
        public LodgersUI()
        {
            InitializeComponent();
            LodgersTable.Items.Clear();
            UpdateAgents();
        }

        private void UpdateAgents()
        {
            LodgersTable.ItemsSource = null;
            LodgersTable.ItemsSource = MainWindow.DB.Lodgers.ToList();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            if (LodgersTable.SelectedItem != null) MessageBox.Show("Выберите постояльца!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                Lodgers lodger = new Lodgers();
                int i = 0;
                foreach (var lodgera in MainWindow.DB.Lodgers.ToList())
                {
                    if (LodgersTable.SelectedIndex == i)
                    {
                        lodger = lodgera;
                        break;
                    }
                    i++;
                }
                Windows.LodgersUpdate win = new Windows.LodgersUpdate(lodger);
                win.ShowDialog();
                UpdateAgents();
            }
        }
    }
}
