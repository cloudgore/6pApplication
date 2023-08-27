using _6p.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для BuildingPlan.xaml
    /// </summary>
    public partial class BuildingPlan : Page
    {
        private CoordinateClass cc = new CoordinateClass();
        private FileClass fc = new FileClass();
        private BackgroundWorker worker = new BackgroundWorker();
        private MessageInfo msg = new MessageInfo();


        public BuildingPlan()
        {
            InitializeComponent();
            DataContext = cc;
            ResultTb.DataContext = fc;
            extTb.DataContext = msg;

            if (FileClass.SavePathAllProgramm != null)
            {
                cc.Init(FileClass.SavePathAllProgramm);
                ResultTb.Text = FileClass.SaveNamePath;

            }
        }

        private async void BuildPlanClick(object sender, RoutedEventArgs e)
        {
           await cc.AsyncBuildPlan(msg);
            ResultTb.Text = FileClass.SaveNamePath;
        }

      
      
        private async void BuildPointClick(object sender, RoutedEventArgs e)
        {
          await  cc.AsyncBuildPoint(msg);
            ResultTb.Text = FileClass.SaveNamePath;

        }

        private async void NamePointClick(object sender, RoutedEventArgs e)
        {
          await  cc.AsyncNamePointn(msg);
            ResultTb.Text = FileClass.SaveNamePath;

        }

        private async void BuildPlanInOnePlaneClick(object sender, RoutedEventArgs e)
        {

            await cc.AsyncBuildInOnePlan(msg);

            ResultTb.Text = FileClass.SaveNamePath;

        }

        private void OpnFileClick(object sender, RoutedEventArgs e)
        {
            string filePath = fc.OpenFile();
            cc.Init(filePath);
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
