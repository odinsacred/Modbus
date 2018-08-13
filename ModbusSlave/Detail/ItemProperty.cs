using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave
{
    class ItemProperty : INotifyPropertyChanged
    {
        private string propertyName;
        private string propertyValue;
        private string Name;

        public string PropertyName
        {
            get
            {
                return propertyName;
            }
            set
            {
                propertyName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PropertyName"));
            }
        }

        public string PropertyValue
        {
            get
            {
                return propertyValue;
            }
            set
            {
                propertyValue = value;
                OnPropertyChanged(new PropertyChangedEventArgs("propertyValue"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);

        }
    }
}
