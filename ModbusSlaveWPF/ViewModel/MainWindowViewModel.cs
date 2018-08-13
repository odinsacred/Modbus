using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModbusSlaveWPF.Model;

namespace ModbusSlaveWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private INode selectedNode;

        public ObservableCollection<INode> Nodes { get; set; } = new ObservableCollection<INode>();

        public INode SelectedNode
        {
            get { return selectedNode; }
            set
            {
                selectedNode = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedNode"));
            }
        }

        public MainWindowViewModel()
        {
            MainItem mainItem = new MainItem();
            mainItem.ItemName = "Master Node";
            mainItem.type = NodeTypes.master;
            //mainItem.Children.Add(new DummyNode());
            Nodes.Add(mainItem);
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                   (addCommand = new RelayCommand(obj =>
                   {
                       MessageBox.Show("Click!");
                       //INode node = obj as INode;
                       //if (node != null)
                       //{
                       //    Nodes.Insert(0, node);
                       //}
                   }));
                //(obj) => Nodes.Count > 0));
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
