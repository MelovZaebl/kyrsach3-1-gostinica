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
using System.Windows.Forms;

namespace Курсач.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClassesUI.xaml
    /// </summary>
    public partial class ClassesUI : Page
    {
        public ClassesUI()
        {
            InitializeComponent();
            ClassesTable.Items.Clear();
            UpdateAgents();
        }

        private void UpdateAgents()
        {
            ClassesTable.ItemsSource = null;
            ClassesTable.ItemsSource = MainWindow.DB.Classes.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            int style = 1;
            Classes classs = new Classes();
            Windows.ClassesUpdate win = new Windows.ClassesUpdate(classs, style);
            win.ShowDialog();
            UpdateAgents();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            int style = 2;
            Classes classs = new Classes();
            int i = 0;
            foreach (var classa in MainWindow.DB.Classes.ToList())
            {
                if (ClassesTable.SelectedIndex == i)
                {
                    classs = classa;
                    break;
                }
                i++;
            }
            Windows.ClassesUpdate win = new Windows.ClassesUpdate(classs, style);
            win.ShowDialog();
            UpdateAgents();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var deletedClass = ClassesTable.SelectedItem as Classes;
            if (deletedClass != null)
            {
                if (MessageBox.Show("Вместе с данным классом удалятся и все комнаты данного класса!", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    foreach (var room in MainWindow.DB.Rooms.ToList())
                    {
                        if (room.Class == deletedClass.ClassID)
                        {
                            MainWindow.DB.Rooms.Remove(room);
                        }
                    }
                    MainWindow.DB.Classes.Remove(deletedClass);
                    MainWindow.DB.SaveChanges();
                    UpdateAgents();
                }
            }
            else MessageBox.Show("Выберите запись для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
