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

            ImageBrush RoomImg = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(Room.Photo));
            RoomImg.ImageSource = image.Source;
            Img.Background = RoomImg;

            CBStatus.Items.Add("Занята");
            CBStatus.Items.Add("Свободна");
            if (Room.Status == true)
            {
                CBStatus.SelectedIndex = 0;
            }
            else CBStatus.SelectedIndex = 1;
        }

        public readonly string DirPath = AppDomain.CurrentDomain.BaseDirectory;

        private void ImgDrop(object sender, DragEventArgs e)
        {
            ImageBrush RoomImg = new ImageBrush();
            Image image = new Image();
            Img.Items.Clear();
            string[] file_pathes = (string[])e.Data.GetData(DataFormats.FileDrop); //массив file_pathes содержит пути к выбранным файлам или папкам при попытке перетащить
            foreach(var path in file_pathes)
            {
                string new_path = DirPath + Path.GetFileName(path); //новый путь файла
                if (File.Exists(new_path) == true)
                {
                    MessageBox.Show("Изображение с таким названием уже используется!\nПереименуйте изображение.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else File.Copy(path, new_path);
                Img.Items.Add(new FileObject(Path.GetFileName(path), new_path));
                Room.Photo = new_path;
                image.Source = new BitmapImage(new Uri(new_path));
                RoomImg.ImageSource = image.Source;
                Img.Background = RoomImg;
            }
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

        private void EditSave(object sender, RoutedEventArgs e)
        {
            string error = String.Empty;
            if (String.IsNullOrWhiteSpace(Room.Room.ToString()))
            {
                error += "Введите номер комнаты.\n";
            }
            if (String.IsNullOrWhiteSpace(Room.Class.ToString()))
            {
                error += "Выберите класс комнаты.\n";
            }
            if (String.IsNullOrWhiteSpace(Room.Photo))
            {
                Room.Photo = "/Pics/RoomPlaceholder.png";
            }
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (CBStatus.SelectedIndex == 0) Room.Status = true;
                else Room.Status = false;
                MainWindow.DB.SaveChanges();
                this.Close();
            }
        }
    }
}
