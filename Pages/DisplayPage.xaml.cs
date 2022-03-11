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

namespace WpfApp3.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy DisplayPage.xaml
    /// </summary>
    public partial class DisplayPage : Page
    {
        public DisplayPage(Pope pope)
        {
            InitializeComponent();
            Title.Content = pope.Name;
            Description.Content = pope.Description;
            ImageCtrl.Source = new BitmapImage(new Uri(pope.ImagePath, UriKind.Relative));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new StartPage();
        }
    }
}
