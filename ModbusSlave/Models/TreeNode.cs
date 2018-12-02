using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.Models
{
    public class TreeNode : Screen, INotifyPropertyChanged
    {
        public TreeNode()
        {
            Children = new ObservableCollection<TreeNode>();
            //DetailsView = new TreeNodeDetailsView();
        }

        public bool IsExpanded { get; set; }

        public bool IsSelected { get; set; }

        public NodeTypes type { get; set; }

        public string Name
        {
            get { return name; }
            protected set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        //public TreeNodeDetailsView DetailsView { get; protected set; }

        public string Icon
        {
            get { return icon; }
            protected set
            {
                icon = value;
                NotifyPropertyChanged("Icon");
            }
        }

        public ObservableCollection<TreeNode> Children { get; private set; }

        //public virtual IList<ICommand> Commands { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public virtual void Dispose()
        {
        }

        private string icon;

        private string name;
    }
}
