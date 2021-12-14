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
    /// Логика взаимодействия для ClassesUI.xaml
    /// </summary>
    public partial class ClassesUI : Page
    {
        public ClassesUI(int style)
        {
            InitializeComponent();
            ClassesTable.Items.Clear();
            UpdateAgents();
            if(style == 1)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Hidden;
            }
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
                    foreach(Rooms room in MainWindow.DB.Rooms.ToList().Where(r => r.Class == deletedClass.ClassID))
                    {
                        if(room.OrdersReg.Count == 0)
                        {
                            int i = 0;
                            //foreach (Rooms deletedRoom in deletedClass.Rooms)
                            //{
                            //    if (deletedRoom.Status == true) i++;
                            //}
                            if (i == 0)
                            {
                                List<Rooms> roomi = new List<Rooms>();
                                foreach (Rooms deletedRoom in deletedClass.Rooms)
                                {
                                    roomi.Add(deletedRoom);
                                    //MainWindow.DB.Rooms.Remove(deletedRoom);
                                }
                                foreach(Rooms rooma in roomi)
                                {
                                    MainWindow.DB.Rooms.Remove(rooma);
                                }
                                MainWindow.DB.Classes.Remove(deletedClass);
                                MainWindow.DB.SaveChanges();
                                UpdateAgents();
                            }
                            else MessageBox.Show("Невозможно удалить комнаты в которых кто-то живет!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("Невозможно удалить комнаты с активной бронью", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else MessageBox.Show("Выберите запись для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
