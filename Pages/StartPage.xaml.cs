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
using System.Diagnostics;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private List<Pope> test = new();
        public StartPage()
        {
            InitializeComponent();
            test.Add(new Pope(1, "Fasolkowy Papież", "LOLOLO", "/Pages/icon.png"));
            test.Add(new Pope(2, "Papież Królik", "LOLOLO", "/Pages/bhub.jpg"));
            test.Add(new Pope(3, "Niewidzialny Papież", "LOLOLO"));
            PopeList.ItemsSource = test;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new AddPage();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Content = new DeletePage();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = new AddPage();
        }

        private void Test(object sender, MouseButtonEventArgs e)
        {
            //test.Add(new Pope(3, "Niewidzialny Papież", "LOLOLO"));
            //Console.WriteLine("TEST");
            Trace.WriteLine("text");
        }

        void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var pope = ((FrameworkElement)e.OriginalSource).DataContext as Pope;
            if (pope != null)
            {
                NavigationService.Content = new DisplayPage(pope);
            }
        }
    }
}
