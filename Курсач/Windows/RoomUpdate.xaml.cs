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
    /// Логика взаимодействия для RoomUpdate.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        private Rooms Room;
        public RoomUpdate(Rooms room)
        {
            InitializeComponent();
            Room = room;
            DataContext = room;

        }
    }
}
