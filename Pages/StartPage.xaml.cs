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
        public static List<Pope> test = new() { 
            new Pope(1, "Fasolkowy Papież", "LOLOLO", "/Pages/icon.png"),
            new Pope(2, "Papież Królik", "Papież królik zwany również papieżem wielkim \n\n\n Papież królik to królik papież. \n Dziękuję za uwagę.", "/Pages/bhub.jpg"), 
            new Pope(3, "Niewidzialny Papież", "LOLOLO", "/Pages/null.png") };
        

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
            var pope = PopeList.SelectedItem as Pope;
            if (pope == null)
                return;

            Trace.WriteLine(pope.Name);
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var pope = PopeList.SelectedItem as Pope;
            if (pope == null)
                return;

            NavigationService.Content = new AddPage(pope);
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
            if (pope == null)
                return;

            NavigationService.Content = new DisplayPage(pope);
        }
    }
}
