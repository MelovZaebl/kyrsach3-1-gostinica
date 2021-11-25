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
using System.IO;

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
            CBClasses.ItemsSource = MainWindow.DB.Classes.ToList();
        }

        public readonly string DirPath = AppDomain.CurrentDomain.BaseDirectory;

        private void ImgDrop(object sender, DragEventArgs e)
        {
            Img.Items.Clear();
            string file_pathes = (string)e.Data.GetData(DataFormats.FileDrop); //массив file_pathes содержит пути к выбранным файлам или папкам при попытке перетащить
            string new_path = DirPath + "Pics/" + Path.GetFileName(file_pathes); //новый путь файла
            File.Copy(file_pathes, new_path); //копирование файла
            Img.Items.Add(new FileObject(Path.GetFileName(file_pathes), new_path)); //добавление в список элемента FileObject (который содержит информацию о файле)
            Room.Photo = new_path;
        }

        class FileObject
        {
            public string Name { get; set; }

            public string FullName { get; set; }

            public FileObject(string name, string fullname)
            {
                Name = name;
                FullName = fullname;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
