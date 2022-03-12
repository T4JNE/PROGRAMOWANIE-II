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
using Microsoft.Win32;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private bool editMode = false;
        private string imagePath;
        private Pope pope;

        public AddPage()
        {
            InitializeComponent();
            editMode = false;
        }

        public AddPage(Pope pope)
        {
            InitializeComponent();
            Title.Text = pope.Name;
            Description.Text = pope.Description;
            imagePath = pope.ImagePath;
            try
            {
                ImageCtrl.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            }
            catch (System.ArgumentNullException)
            {
                pope.ImagePath = "/Pages/null.png";
                imagePath = "/Pages/null.png";
                ImageCtrl.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            }
            
            ApplyButton.Content = "Edytuj";
            editMode = true;
            this.pope = pope;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new StartPage();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new();

            file.Filter = "Image Files(*.BMP;*.JPG; *.PNG; *.GIF)|*.BMP;*.JPG;*.PNG;*.GIF";
            file.DefaultExt = ".png";

            if (file.ShowDialog() == true)
            {
                imagePath = file.FileName;
                ImageCtrl.Source = new BitmapImage(new Uri(imagePath));
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!editMode)
            {
                StartPage.test.Add(new Pope(StartPage.test.Count + 1, Title.Text, Description.Text, imagePath));
            }
            else
            {
                int i = StartPage.test.IndexOf(pope);
                StartPage.test[i].ImagePath = imagePath;
                StartPage.test[i].Name = Title.Text;
                StartPage.test[i].Description = Description.Text;
            }

            NavigationService.Content = new StartPage();
        }
    }
}
