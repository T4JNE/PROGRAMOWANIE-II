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
using WpfApp3.Pages;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public static List<string> test = new() { "Jan Papież 2", "Carl Wojtyła", "Benek 16", "Franio"};
        public StartPage()
        {
            InitializeComponent();
            PopeList.ItemsSource = test;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new AddPage();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new DeletePage();
        }
    }
}
