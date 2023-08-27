using _6p.Classes;
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

namespace _6p.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProdolProfilePage.xaml
    /// </summary>
    public partial class ProdolProfilePage : Page
    {
        private CoordinateClass cc = new CoordinateClass();
        private FileClass fc = new FileClass();
        private MessageInfo msg = new MessageInfo();

        public ProdolProfilePage()
        {
            InitializeComponent();
            DataContext = cc;
            ResultTb.DataContext = FileClass.SaveNamePath;
            extTb.DataContext = msg;
            if (FileClass.SavePathAllProgramm != null)
            {
                cc.Init(FileClass.SavePathAllProgramm);
                ResultTb.Text = FileClass.SaveNamePath;

            }
        }

        private async void ProdolButton_Click(object sender, RoutedEventArgs e)
        {
            await cc.AsyncProdolProfile(msg);
            ResultTb.Text = FileClass.SaveNamePath;

        }

        private async void NamePointClick(object sender, RoutedEventArgs e)
        {
            await cc.AsyncPoint(msg);
            ResultTb.Text = FileClass.SaveNamePath;

        }
        private void OpnFileClick(object sender, RoutedEventArgs e)
        {
            string filePath = fc.OpenFile();
            cc.Init(filePath);
            ResultTb.Text = FileClass.SaveNamePath;

        }
        private  async void LinePerelomClick(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => cc.AsyncPerelom(msg));
                ResultTb.Text = FileClass.SaveNamePath;
        }

        private  async void ReplaceX1Y1Click(object sender, RoutedEventArgs e)
        {
            await cc.AsyncX1Y1(false, msg);
            ResultTb.Text = FileClass.SaveNamePath;
        }

        private async void ReplaceX2Y2Click(object sender, RoutedEventArgs e)
        {
            await cc.AsyncX2Y2(false,msg);
            ResultTb.Text = FileClass.SaveNamePath;
        }
        private void AltitudinalDifferenceClick(object sender, RoutedEventArgs e)
        {

        }
        private async void ResulAutoCadClick(object sender, RoutedEventArgs e)
        {
            if (CheckX1Y1.IsChecked == false && CheckX2Y2.IsChecked == false)
                MessageBox.Show("Выберите какой результат вам нужен!");
            else if (CheckX1Y1.IsChecked == true)
                await cc.AsyncX1Y1(true,msg);
            else if (CheckX2Y2.IsChecked == true)
                await cc.AsyncX2Y2(true, msg);

            else if (CheckX1Y1.IsChecked == true && CheckX2Y2.IsChecked == true)
                MessageBox.Show("Нужно выбрать что-то одно!");

            ResultTb.Text = FileClass.SaveNamePath;


        }

        private void CheckX1Click(object sender, RoutedEventArgs e)
        {
              if (CheckX1Y1.IsChecked == true)
                CheckX2Y2.IsChecked = false;
            ResultTb.Text = FileClass.SaveNamePath;

        }

        private void CheckX2Click(object sender, RoutedEventArgs e)
        {
            if (CheckX2Y2.IsChecked == true)
                CheckX1Y1.IsChecked = false;
            ResultTb.Text = FileClass.SaveNamePath;

        }

        private void FilleDropEvent(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
                string[] name = path[0].Split('\\');
                cc.Init(path[0]);
                FileClass.SaveNamePath = name[name.Length - 1];
                FileClass.SavePathAllProgramm = path[0];
                ResultTb.Text = FileClass.SaveNamePath;
            }
        }
    }
}
