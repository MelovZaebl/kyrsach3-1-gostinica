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
    /// Логика взаимодействия для ClassesUpdate.xaml
    /// </summary>
    public partial class ClassesUpdate : Window
    {
        private Classes classs;
        public ClassesUpdate(Classes classd, int style)
        {
            InitializeComponent();
            this.classs = classd;
            DataContext = classd;
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
            if (String.IsNullOrWhiteSpace(classs.ClassName) || classs.ClassName.Count() > 50)
            {
                error += "Введите название класса.\n";
            }
            if (String.IsNullOrWhiteSpace(classs.SpotsCount.ToString()))
            {
                error += "Введите кол-во мест.\n";
            }
            if (String.IsNullOrWhiteSpace(classs.DailyPrice.ToString()))
            {
                error += "Введите стоимость за день.\n";
            }
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (classs.ClassID == 0)
                {
                    MainWindow.DB.Classes.Add(classs);
                    MainWindow.DB.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка 404", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(classs.ClassName) || classs.ClassName.Count() > 50)
            {
                error += "Введите название класса.\n";
            }
            if (String.IsNullOrWhiteSpace(classs.SpotsCount.ToString()))
            {
                error += "Введите кол-во мест.\n";
            }
            if (String.IsNullOrWhiteSpace(classs.DailyPrice.ToString()))
            {
                error += "Введите стоимость за день.\n";
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
    }
}
