using _6p.Pages;
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

namespace _6p
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlantClick(object sender, RoutedEventArgs e)
        {
            FrameNavigate.Navigate(new BuildingPlan());

        }

        private void ProdolProfileClck(object sender, RoutedEventArgs e)
        {
            FrameNavigate.Navigate(new ProdolProfilePage());
        }
    }
}
