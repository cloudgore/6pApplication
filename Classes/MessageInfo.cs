using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6p.Classes
{
  public   class MessageInfo : INotifyPropertyChanged
    {
       public enum OperationInfo
        {
            Succsesful,
            Wait,
            Exception
        }
         private static string _InfoOperation;
        public string InfoOperation
        {
            get
            {
              return _InfoOperation;
            }
        set
        {
                _InfoOperation = value;
                UpdateData("InfoOperation");
        }
        }
        public MessageInfo()
        {
            InfoOperation = "Здесь будет результат выполнения";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateData(string fileName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(fileName));
            }
        }

        public  void Operation(OperationInfo op)
        {
            switch(op)
            {
                case OperationInfo.Succsesful:
                    InfoOperation = "Успешно";
                    break;
                case OperationInfo.Wait:
                    InfoOperation = "Подождите";
                    break;
                case OperationInfo.Exception:
                    InfoOperation = "Ошибка";
                    break;
            }
        }

    }
}
