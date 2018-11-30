using ModbusSlave.Models;
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

namespace ModbusSlave.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }
        #region selecting treeViewItem by mouse right click

        private void TreeView1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
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

        //private void DetailsViewLoadCompleted(object sender, NavigationEventArgs e)
        //{
        //    UpdateDetailsViewDataContext(sender);
        //}

        //private void DetailsViewDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    UpdateDetailsViewDataContext(sender);
        //}

        //private static void UpdateDetailsViewDataContext(object sender)
        //{
        //    var frame = (Frame)sender;
        //    var content = frame.Content as FrameworkElement;
        //    if (content == null)
        //        return;
        //    content.DataContext = frame.DataContext;
        //}
    }
}
