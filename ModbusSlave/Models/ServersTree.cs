using ModbusSlave.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.Models
{
    public class ServersTree
    {
        //public IRunContext Context { get; set; }

        public ServersTree(/*IRunContext runContext*/)
        {
            //Context = runContext;
            Children = new ObservableCollection<TreeNode>
            {
                new LocalHostViewModel(this),
            };
        }

        public ObservableCollection<TreeNode> Children { get; private set; }

        public void Dispose()
        {
            DisposeChildren(Children);
        }

        private static void DisposeChildren(IEnumerable<TreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                DisposeChildren(node.Children);
                node.Dispose();
            }
        }
    }
}
