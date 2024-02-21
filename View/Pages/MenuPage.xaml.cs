using PetrovaControl7.AppData;
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

namespace PetrovaControl7.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void MakerBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.MakerPage());
        }

        private void ProductAddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.ProductPage());
        }

        private void WorkerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.WorkerPage());
        }

        private void AccAddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.AccAddPage());
        }

        private void AccViewBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.AccPeriodPage());
        }

        private void AccWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.AccWorkerPage());
        }
    }
}
