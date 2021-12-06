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
    /// Логика взаимодействия для WorkersUpdate.xaml
    /// </summary>
    public partial class WorkersUpdate : Window
    {
        private Workers Worker;
        public WorkersUpdate(Workers worker, int style)
        {
            InitializeComponent();
            this.Worker = worker;
            DataContext = worker;
            if (style == 1)
            {
                btnSave.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Hidden;
            }
            else if (style == 2)
            {
                btnSave.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Visible;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(Worker.FIO) || Worker.FIO.Count() > 50)
            {
                error += "Введите ФИО.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.Doljnost) || Worker.Doljnost.Count() > 50)
            {
                error += "Введите должность.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.Phone) || Worker.Phone.Count() != 11)
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
                if(Worker.Doljnost == "Администратор гостиницы" || Worker.Doljnost == "Администратор приложения")
                {
                    MessageBox.Show("Персонал работающий с программой добавляется через раздел \"Пользователи\"", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
                else
                {
                    if (Worker.ID == 0)
                    {
                        MainWindow.DB.Workers.Add(Worker);
                        MainWindow.DB.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка 404", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(Worker.FIO) || Worker.FIO.Count() > 50)
            {
                error += "Введите ФИО.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.Doljnost) || Worker.Doljnost.Count() > 50)
            {
                error += "Введите должность.\n";
            }
            if (String.IsNullOrWhiteSpace(Worker.Phone) || Worker.Phone.Count() > 11)
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
                    MainWindow.DB.SaveChanges();
                    this.Close();
            }
        }

        private void FIOInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void DoljnostInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void PhoneInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
