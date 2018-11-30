using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ModbusSlave.Models
{
    public class PortNode : TreeNode
    {
        public PortNode(LocalHostNode owner)
        {
            Owner = owner;
            type = NodeTypes.port;
            Name = "Name PortGroupNode";
            Icon = "/Images/DAGroup.png";
            DetailsView = new TreeNodeDetailsView
            {
                Page = new Uri("PortView.xaml", UriKind.Relative),
                //Data = Items,
            };
        }

        public LocalHostNode Owner { get; private set; }


        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set
            {
                isInEditMode = value;
                NotifyPropertyChanged("IsInEditMode");
            }
        }

        // it might happen, that the user pressed F2 while a non-editable item was selected
        public void TreeView_SelectedItemChanged(object sender)
        {
            IsInEditMode = false;
        }
        // This flag indicates whether the tree view items shall (if possible) open in edit mode
        bool isInEditMode = false;
        // we (possibly) switch to edit mode when the user presses F2
        public void TreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
                IsInEditMode = true;
        }

        // the user has clicked a header - proceed with editing if it was selected
        public void TextBlockHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (FindTreeItem(e.OriginalSource as DependencyObject).IsSelected)
            {
                IsInEditMode = true;
                e.Handled = true;       // otherwise the newly activated control will immediately loose focus
            }
        }

        static TreeViewItem FindTreeItem(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);
            return source as TreeViewItem;
        }

        string oldText;

        public void EditableTextBoxHeader_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.IsVisible)
            {
                tb.Focus();
                tb.SelectAll();
                oldText = tb.Text;      // back up - for possible cancelling
            }
        }

        public void EditableTextBoxHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                IsInEditMode = false;
            if (e.Key == Key.Escape)
            {
                var tb = sender as TextBox;
                tb.Text = oldText;
                IsInEditMode = false;
            }
        }

        public void EditableTextBoxHeader_LostFocus(object sender)
        {
            IsInEditMode = false;
        }

    }
}
