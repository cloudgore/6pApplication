using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _6p.Classes
{
    public class CoordinateClass : INotifyPropertyChanged
    {
        public List<int> NumberPoint = new List<int>();
        public List<double> Y = new List<double>();
        public List<double> X = new List<double>();
        public List<double> Z = new List<double>();
        public List<double> DistancePoint = new List<double>();
        public const int Zero = 0;
        public const int ThreeCordinate = 0;
      
        public List<double> KoordinateMasgtab = new List<double>();
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }

        public List<double> X1list = new List<double>();
        public List<double> Y1list = new List<double>();
        public List<double> X2list = new List<double>();
        public List<double> Y2list = new List<double>();
        public double cofX = 0;
        public double cofY = 0;
        public double cofX2 = 0;
        public double cofY2 = 0;
        public List<double> SumMachtab = new List<double>();

        private StringBuilder str = new StringBuilder();

        public event PropertyChangedEventHandler PropertyChanged;

        private double _ugol = 0;
        public double ugol
        {
            get
            {
                return _ugol;
            }
            set
            {
                _ugol = value;
                UpdateData("ugol");
            }
        }

        private double _MashatPoVert = 1;
        public double MashatPoVert 
        {
            get
            {
                return _MashatPoVert;
            }
            set
            {
                _MashatPoVert = value;
                UpdateData("MashatPoVert");
            }
        }

        private double _MashatPoGorizontal = 100;
        public double MashatPoGorizontal
        {
            get
            {
                return _MashatPoGorizontal;
            }
            set
            {
                _MashatPoGorizontal = value;
                UpdateData("MashatPoGorizontal");
            }
        }
        private string _TK;
        public string TK
        {
            get
            {
                return _TK;
            }
            set
            {
                _TK = value;
                UpdateData("TK");
            } 
        }
        public void UpdateData(string fileName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(fileName));
            }
        }
        private double _Font2 = 1;

        public double Font2
        {
            get
            {
                return _Font2;
            }
            set
            {
                _Font2 = value;
                UpdateData("Font2");
            }
        }
        private string _distanceTrack;

        public string distanceTrack
        {
            get
            {
                return _distanceTrack;
            }
            set
            {
                _distanceTrack = value;
                UpdateData("distanceTrack");
            }
        }
        public async Task AsyncBuildPoint(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => BuildPoint(msg));
        }
        public void BuildPoint(MessageInfo msg)
        {
            if (X.Count() == 0)
            {
               
            }
            else
            {
                str.Clear();
                for (int i = 0; i < X.Count(); i++)
                {
                    try
                    {
                         str.Append( $"точка {X[i].ToString(CultureInfo.InvariantCulture)}," +
                             $"{Y[i].ToString(CultureInfo.InvariantCulture)},{Z[i].ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
                    }
                    catch
                    {

                    }
                }
                Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                msg.Operation(MessageInfo.OperationInfo.Succsesful);
            }
        }
        public async Task AsyncNamePointn(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => NamePoint(msg));
        }
        public void NamePoint(MessageInfo msg)
        {

            if (X.Count() == 0)
            {
            }
            else
            {
                str.Clear();
                for (int i = 0; i < X.Count(); i++)
                {
                    try
                    {
                        str.Append($"-текст {X[i].ToString(CultureInfo.InvariantCulture)},{Y[i].ToString(CultureInfo.InvariantCulture)} {Font2.ToString(CultureInfo.InvariantCulture)} {ugol.ToString(CultureInfo.InvariantCulture)} {NumberPoint[i]}{Environment.NewLine}");


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                msg.Operation(MessageInfo.OperationInfo.Succsesful);
            }
        }
        public async Task AsyncBuildInOnePlan(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => BuildPlanInOnePlan(msg));
        }

        public void BuildPlanInOnePlan(MessageInfo msg)
        {
            if (X.Count() == 0)
            {
              
            }
            else
            {
                str.Clear();
                for (int i = 0; i < X.Count(); i++)
                {
                    str.Append($"отрезок {X[i].ToString(CultureInfo.InvariantCulture)},{Y[i].ToString(CultureInfo.InvariantCulture)},0{Environment.NewLine}");
                }
                Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                msg.Operation(MessageInfo.OperationInfo.Succsesful);
            }
        }
        public async Task AsyncBuildPlan(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => BuildPlan(msg));
        }

        private void BuildPlan(MessageInfo msg)
        {
            if (X.Count() == 0)
            {
         
            }
            else
            {
                str.Clear();

                for (int i = 0; i < X.Count(); i++)
                {
                    str.Append($"отрезок {X[i].ToString(CultureInfo.InvariantCulture)},{Y[i].ToString(CultureInfo.InvariantCulture)},{Z[i].ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
                }
                Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                msg.Operation(MessageInfo.OperationInfo.Succsesful);
            }
        }

        public void Init(string filePath)
        {
            try
            {
                X.Clear();
                Y.Clear();
                Z.Clear();
                string[] vs = File.ReadAllLines(filePath);
                vs = File.ReadAllLines(filePath);
                for (int i = 0; i < vs.Length; i++)
                {
                    if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1) // win7
                    {
                        string[] a = vs[i].Replace(',', ';').Replace('.', ',').Split(';');
                        try
                        {
                            NumberPoint.Add(Convert.ToInt32(a[0]));
                            X.Add(Convert.ToDouble(a[1]));
                            Y.Add(Convert.ToDouble(a[2]));
                            Z.Add(Convert.ToDouble(a[3]));
                            TK = a[4];
                        }
                        catch
                        {
                        }
                    }
                    else 
                    {
                        string[] a = vs[i].Replace(',', ';').Split(';');
                        try
                        {
                            NumberPoint.Add(Convert.ToInt32(a[0]));
                            X.Add(Convert.ToDouble(a[1]));
                            Y.Add(Convert.ToDouble(a[2]));
                            Z.Add(Convert.ToDouble(a[3]));
                            TK = a[4];
                        }
                        catch
                        {
                        }
                    }

                }
                for (int i = 0; i < Z.Count()  ; i++)
                {
                    KoordinateMasgtab.Add(Z[i] / MashatPoVert);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
           
            Distance();
            try
            {
                double last = SumMachtab.Last();
                distanceTrack = $"Общая длинна трассы от \n {NumberPoint[0]} точки до {NumberPoint.Last()}  \n точки составляет { last * MashatPoGorizontal} метров".ToUpper();
            }
            catch
            {

            }
          
        }
        List<double> ZList = new List<double>();
        private void X2Y2( bool forAutoCAD,MessageInfo msg)
        {
            X2list.Clear();
            Y2list.Clear();
            Distance();

            if (X2 > Y2)
            {
                str.Clear();
                try
                {
                    cofX2 = (X[0] - X2) * (X[0] - X2);
                    cofY2 = (Y[0] - Y2) * (Y[0] - Y2);

                    for (int i = 0; i < X.Count(); i++)
                    {
                        X2list.Add(X[i] - Math.Sqrt(cofX2));

                    }
                    for (int i = 0; i < X.Count(); i++)
                    {
                        Y2list.Add(Y[i] + Math.Sqrt(cofY2));

                    }

                    for (int i = 0; i < Y2list.Count(); i++)
                    {
                        if (forAutoCAD == true)
                        {
                            str.Append($"отрезок {X2list[i].ToString(CultureInfo.InvariantCulture)},{Y2list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
                        }
                        else
                        {
                            str.Append($"{NumberPoint[i]},{X2list[i].ToString(CultureInfo.InvariantCulture)},{Y2list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)},{TK}{Environment.NewLine}");
                        }
                    }

                }
                catch
                {

                }
            }
            else if (X2 < Y2)
            {
                str.Clear();
                try
                {
                    cofX2 = (X[0] - X2) * (X[0] - X2);
                    cofY2 = (Y[0] - Y2) * (Y[0] - Y2);

                    for (int i = 0; i < X.Count(); i++)
                    {
                        X2list.Add(X[i] + Math.Sqrt(cofX2));

                    }
                    for (int i = 0; i < X.Count(); i++)
                    {
                        Y2list.Add(Y[i] + Math.Sqrt(cofY2));
                    }

                    for (int i = 0; i < Y2list.Count(); i++)
                    {
                        if (forAutoCAD == true)
                        {
                            str.Append($"отрезок {X2list[i].ToString(CultureInfo.InvariantCulture)},{Y2list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
                        }
                        else
                        {
                            str.Append($"{NumberPoint[i]},{X2list[i].ToString(CultureInfo.InvariantCulture)},{Y2list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)},{TK}{Environment.NewLine}");

                        }

                    }

                }
                catch
                {

                }
            }
            Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            msg.Operation(MessageInfo.OperationInfo.Succsesful);
        }
        private void X1Y1(bool forAutoCAD,MessageInfo msg)
        {
            X1list.Clear();
            Y1list.Clear();
        //    StringBuilder str = new StringBuilder();
            Distance();

            try
            {
              //  cofX = (X[0] - X1 * (X[0] - X1));
                cofX = Math.Pow((X[0] - X1),2);

                cofY = (Y[0] - Y1 * (Y[0] - Y1));
                cofY  = Math.Pow(Y[0] - Y1,2);

                if (X1 < Y1)
                {
                    str.Clear();
                    for (int i = 0; i < X.Count(); i++)
                    {
                        X1list.Add(X[i] - Math.Sqrt(cofX));
                        Y1list.Add(Y[i] - Math.Sqrt(cofY));
                    }

                    for (int i = 0; i < Y1list.Count(); i++)
                    {
                        if(forAutoCAD == true)
                        {
                                str.Append($"отрезок {X1list[i].ToString(CultureInfo.InvariantCulture)},{Y1list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
                           
                                
                        }
                        else
                        {

                            str.Append($"{NumberPoint[i]},{X1list[i].ToString(CultureInfo.InvariantCulture)},{Y1list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)},{TK}{Environment.NewLine}");
                        }
                    }
                }
                else if (X1 > Y1)
                {
                    str.Clear();
                    for (int i = 0; i < X.Count(); i++)
                    {
                        X1list.Add(X[i] + Math.Sqrt(cofX));
                        Y1list.Add(Y[i] - Math.Sqrt(cofY));
                    }
                    for (int i = 0; i < Y1list.Count(); i++)
                    {
                        if(forAutoCAD == true)
                        {
                            str.Append($"отрезок {X1list[i].ToString(CultureInfo.InvariantCulture)},{Y1list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
                        }
                        else
                        {
                            str.Append($"{NumberPoint[i]},{X1list[i].ToString(CultureInfo.InvariantCulture)},{Y1list[i].ToString(CultureInfo.InvariantCulture)},{ZList[i].ToString(CultureInfo.InvariantCulture)},{TK}{Environment.NewLine}");
                        }
                    }
                }
            }
            catch
            {
            }
            Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            msg.Operation(MessageInfo.OperationInfo.Succsesful);
        }
        public async Task AsyncX2Y2(bool ForAutoCAD,MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => ReplaceX2Y2(ForAutoCAD,msg));
        }

        public async Task AsyncX1Y1(bool ForAutoCAD, MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => ReplaceX1Y1(ForAutoCAD, msg));
        }
        public void ReplaceX2Y2( bool ForAutoCAD,MessageInfo msg)
        {

            ZList.Clear();
            MessageBox.Show("Выберите файл формата *.txt, который содержит информацию о полилинии с проектируемыми отметками, описывающей проектируемый продольный профиль.", "Внимание");
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Текстовые файлы (*.txt)|*.txt";
            d.ShowDialog();
            string filePath = d.FileName;
            try
            {
                string[] vs = File.ReadAllLines(filePath);
                for (int i = 0; i <= vs.Length; i++)
                {
                    //        string[] a = vs[i].Replace(',', ';').Replace('.', ',');
                    if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1) // win7
                    {
                        string[] a = vs[i].Replace(" в точке  ", "").Replace("������� ENTER ��� �����������:", " ")
                                          .Trim(' ').Replace("X", "").Replace("Y", "").Replace("Z", "").Replace(".", ",").Trim(' ').Split('=');
                        if (a[0] == "")
                        {
                        }
                        else
                            ZList.Add(Convert.ToDouble(a[2]));
                    }
                    else
                    {
                        string[] a = vs[i].Replace(" в точке  ", "").Replace("������� ENTER ��� �����������:", " ")
                  .Trim(' ').Replace("X", "").Replace("Y", "").Replace("Z", "").Replace(".", ".").Trim(' ').Split('=');
                        if (a[0] == "")
                        {
                        }
                        else
                            ZList.Add(Convert.ToDouble(a[2]));
                    }
                      
                }
            }
            catch
            {
                //    MessageBox.Show(exp.Message);
            }

            X2Y2(ForAutoCAD,msg);

        }
        public void ReplaceX1Y1(bool ForAutoCAD, MessageInfo msg)
        {
            ZList.Clear();
            MessageBox.Show("Выберите файл формата *.txt, который содержит информацию о полилинии с проектируемыми отметками, описывающей проектируемый продольный профиль.", "Внимание");
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Текстовые файлы (*.txt)|*.txt";
            d.ShowDialog();
            string filePath = d.FileName;
            try
            {
                string[] vs = File.ReadAllLines(filePath);
                for (int i = 0; i <= vs.Length; i++)
                {
                    //        string[] a = vs[i].Replace(',', ';').Replace('.', ',');
                    if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1) // win7
                    {
                        string[] a = vs[i].Replace(" в точке  ", "").Replace("������� ENTER ��� �����������:", " ")
                                           .Trim(' ').Replace("X", "").Replace("Y", "").Replace("Z", "").Replace(".", ",").Trim(' ').Split('=');
                        if (a[0] == "")
                        {
                        }
                        else
                            ZList.Add(Convert.ToDouble(a[2]));
                    }
                    else
                    {
                        string[] a = vs[i].Replace(" в точке  ", "").Replace("������� ENTER ��� �����������:", " ")
                   .Trim(' ').Replace("X", "").Replace("Y", "").Replace("Z", "").Replace(".", ".").Trim(' ').Split('=');
                        if (a[0] == "")
                        {
                        }
                        else
                            ZList.Add(Convert.ToDouble(a[2]));
                    }

                       
                }
            }
            catch 
            {

            }

            X1Y1(ForAutoCAD,msg);

        }
        private double SortToMin()
        {
            Distance();
            double min = 0;
            for (int i = 0; i < KoordinateMasgtab.Count(); i++)
            {
                for (int j = 0; j < KoordinateMasgtab.Count(); j++)
                {
                    try
                    {
                        if (KoordinateMasgtab[j] > KoordinateMasgtab[j + 1])
                        {
                            double temp = KoordinateMasgtab[j];
                            KoordinateMasgtab[j] = KoordinateMasgtab[j + 1];
                            KoordinateMasgtab[j + 1] = temp;
                            min = KoordinateMasgtab[0];

                        }
                    }
                    catch
                    {

                    }
                }
            }
            return KoordinateMasgtab[0];
        }
        public async Task AsyncPerelom(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => Perelom(msg));
           


        }
        public void Perelom(MessageInfo msg)
        {
            double min = SortToMin();
            str.Clear();
            Distance();

            for (int i = 0; i < X.Count() ; i++)
            {
                if (i == 0)
                    str.Append($"отрезок 0,{min.ToString(CultureInfo.InvariantCulture)},0 отрезок 0,{(Z[i] / MashatPoVert).ToString(CultureInfo.InvariantCulture)},0{Environment.NewLine} ");
                try
                {
                    str.Append($"отрезок {SumMachtab[i].ToString(CultureInfo.InvariantCulture)},{min.ToString(CultureInfo.InvariantCulture)},0 отрезок {SumMachtab[i].ToString(CultureInfo.InvariantCulture)},{(Z[i + 1] / MashatPoVert).ToString(CultureInfo.InvariantCulture)},0{Environment.NewLine} ");
                }
                catch
                {
                    msg.Operation(MessageInfo.OperationInfo.Exception);
                }
            }

            Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            msg.Operation(MessageInfo.OperationInfo.Succsesful);

        }

        public async Task AsyncPoint(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => Tochki(msg));
        }

        public void Tochki(MessageInfo msg)
        {
          
            str.Clear();
            for (int i = 0; i < X.Count(); i++)
            {
                if (i == 0)
                {
                    str.Append($"-текст 0," +
                        $"{(Z[i] / MashatPoVert).ToString(CultureInfo.InvariantCulture)} {Font2.ToString((CultureInfo.InvariantCulture))} {ugol.ToString((CultureInfo.InvariantCulture))} {NumberPoint[i]}{Environment.NewLine}");
                }
                try
                {
                    str.Append ($"-текст {SumMachtab[i].ToString(CultureInfo.InvariantCulture)}," +
                        $"{(Z[i + 1] / MashatPoVert).ToString(CultureInfo.InvariantCulture)} {Font2.ToString((CultureInfo.InvariantCulture))} {ugol.ToString((CultureInfo.InvariantCulture))} {NumberPoint[i + 1]}{Environment.NewLine}");
                }
                catch 
                {
                    msg.Operation(MessageInfo.OperationInfo.Exception);

                }
            }
            Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            msg.Operation(MessageInfo.OperationInfo.Succsesful);

        }

        public async Task AsyncProdolProfile(MessageInfo msg)
        {
            msg.Operation(MessageInfo.OperationInfo.Wait);
            await Task.Run(() => ProdolniyProfile(msg)) ;
        }
      
        private void ProdolniyProfile(MessageInfo msg)
        {
            Distance();
            str.Clear();
            msg.Operation(MessageInfo.OperationInfo.Wait);
            for (int i = 0; i < X.Count() - 1; i++)
            {
                if (i == 0)
                {
                        str.Append($"отрезок 0,{(Z[i] / MashatPoVert).ToString(CultureInfo.InvariantCulture)},{ThreeCordinate}{Environment.NewLine}");
                        
                }
                try
                {
                     str.Append($"отрезок {SumMachtab[i].ToString(CultureInfo.InvariantCulture)},{(Z[i + 1] / MashatPoVert).ToString(CultureInfo.InvariantCulture)},{ThreeCordinate}{Environment.NewLine}");
                }
                catch 
                {
                    msg.Operation(MessageInfo.OperationInfo.Exception);
                }
            }
            msg.Operation(MessageInfo.OperationInfo.Succsesful);

            Thread thread = new Thread(() => Clipboard.SetText(str.ToString()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
         

        }
        private void Distance()
        {
            try
            {
                SumMachtab.Clear();
                DistancePoint.Clear();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            double sum = 0;

            DistancePoint.Add(0);

            for (int i = 0; i < X.Count(); i++)
            {
                try
                {
                    double x1 = X[i];
                    double x2 = X[i + 1];
                    double y1 = Y[i];
                    double y2 = Y[i + 1];
                    //  sum = (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2))) / MashatPoGorizontal;//
                    sum = (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2))) / MashatPoGorizontal;

                    DistancePoint.Add(sum); // Расстояние между точками
                }
                catch 
                {
                }
            }

            for (int i = 0; i <= 1; i++)
            {
                try
                {
                    double x1 = DistancePoint[i];
                    double x2 = DistancePoint[i + 1];

                    SumMachtab.Add(x1 + x2);
                }
                catch 
                {
                }
            }
            double suma = 0;
            int StartPoint = 3;
            for (int i = 1; i < DistancePoint.Count(); i++)
            {
                try { 
                
                    double x = SumMachtab[i];
                    double x1 = DistancePoint[StartPoint];
                    suma = x + x1;
                    SumMachtab.Add(suma);

                    if (i != DistancePoint.Count)
                    {
                        StartPoint++;
                    }
                }
                catch 
                {
                }
            }
        }
    }

}
