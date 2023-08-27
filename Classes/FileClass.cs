using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _6p.Classes
{
    public class FileClass : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public static string SavePathAllProgramm;
        public static string SaveNamePath;
        public void UpdateData(string fileName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(fileName));
            }
        }
        private string _fileName;
        public string fileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                UpdateData("fileName");
            }
        }
        public string OpenFile()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Текстовые файлы (*.txt)|*.txt";
            d.ShowDialog();
            string filePath = d.FileName;
            fileName = d.SafeFileName;
            SavePathAllProgramm = d.FileName;
            SaveNamePath = d.SafeFileName;
                return filePath;
        }
    }
}
