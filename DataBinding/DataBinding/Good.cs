using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBinding
{
   public class Good: INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _category;
        private int _count;

        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Login");
            }
        }
        public string Category {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged("Password");
            }
        }
        public int Id {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public int Count {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}