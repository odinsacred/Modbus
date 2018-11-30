using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSlave.Models
{
    public class LocalHostNode : TreeNode
    {
        // localhost - корневой элемент, содержит ноды (или сервера modbus), в нодах - девайсы, в девайсах теги, думаю для всего этого 
        // достаточно коллекции наследуемой из TreeNode

        public LocalHostNode(ServersTree owner)
        {
            Owner = owner;
            Name = "localhost";
            type = NodeTypes.master;
            IsExpanded = true;
            Icon = "/Images/Localhost.png";
        }

        //public ObservableCollection<NodeGroupItem> Items { get; private set; }

        public ServersTree Owner { get; private set; }

        //public override IList<ICommand> Commands
        //{
        //    get { return CommandList; }
        //    protected set { }
        //}

        //TODO: Если не получится реализовать через Caliburn, нужно будет использовать команды
        //private static readonly List<ICommand> CommandList = new List<ICommand>
        //{
        //    new RefreshServersCommand()
        //};
    }
}
