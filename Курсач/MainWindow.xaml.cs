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
using System.IO;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DBEntities DB;
        public MainWindow()
        {
            InitializeComponent();
            DB = new DBEntities();
            MainFrame.Navigate(new Authorization());
            if (Directory.Exists("Pics") == false)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Pics");
            }
        }
    }
}
