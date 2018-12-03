using Caliburn.Micro;
using ModbusLib;
using ComportLib;
using ModbusSlave.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ModbusSlave.ViewModels
{
    public class LocalHostViewModel : TreeNode
    {

        public LocalHostViewModel(ServersTree owner)
        {
            Owner = owner;
            Name = "localhost";
            type = NodeTypes.master;
            IsExpanded = true;
            Icon = "/Images/database-off.png";
        }

        public ServersTree Owner { get; private set; }

        public void CreateSlaves(CancellationToken token)
        {
            PortViewModel portModel;
            foreach (var port in Children)
            {

                portModel = (PortViewModel)port;
                foreach (var device in portModel.Children)
                {
                    IMemoryMap map = ((DeviceViewModel)device).GetMemory();
                    ushort address = ((DeviceViewModel)device).Address;
                    new Slave(address,portModel.GetPort(),map,token);
                    
                }
                               
            }
        }
    }
}
