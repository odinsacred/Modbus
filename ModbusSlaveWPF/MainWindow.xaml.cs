using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Markup;

namespace ModbusSlaveWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<INode> MasterNode { get; set; }

        //public INode CurrentItem { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new MainWindowViewModel();
        }

        private void AddPortContextMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            //PortItem port = new PortItem();
            //port.ItemName = "PORT " + MasterNode[0].Children.Count;
            //MasterNode[0].Children.Add(port);
        }

        private void DeletePortContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddDeviceContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteDeviceContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddFolderContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteFolderContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTagContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTagContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        #region selecting treeViewItem by mouse right click
        private void treeView1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
            }
        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }
        #endregion
    }
}
