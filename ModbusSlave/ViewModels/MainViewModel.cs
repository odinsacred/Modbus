using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using ModbusLib;
using ComportLib;
using System.IO.Ports;
using System.Threading;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Reflection;
using ModbusSlave.Models;
using System.Windows.Navigation;
using System.Windows.Input;
using System.ComponentModel;

namespace ModbusSlave.ViewModels
{
   
    class MainViewModel : Screen
    {

        Slave slave;
        string currentFile;
        SerialComm serialPort;

        Device memoryMap;

        CancellationTokenSource cts;

        public ObservableCollection<ItemProperty> Properties { get; set; }


        public ObservableCollection<INode> MasterNode { get; set; }

        public string Title => "Modbus Slave";

        public string Format => "X";

        public UInt16 DeviceAddress { get; set; } = 1;

        public string[] AvailablePorts => SerialPort.GetPortNames();

        public string SelectedPort { get; set; } = "COM1";

        public int[] BaudRates => new int[] { 115200, 19200, 9600 };

        public int SelectedBaudRate { get; set; } = 115200;

        public int[] DataBits => new int[] { 8, 7 };

        public int SelectedDataBits { get; set; } = 8;

        public StopBits[] _StopBits => new StopBits[] { StopBits.None, StopBits.One, StopBits.Two };

        public StopBits SelectedStopBits { get; set; } = StopBits.One;

        public Parity[] Parities => new Parity[] { Parity.Even, Parity.Odd, Parity.None };

        public Parity SelectedParity { get; set; } = Parity.None;

        public INode SelectedItem { get; set; }


        public string[] RowHeaders { get; }

        public string[] ColumnHeaders { get; }

        private Random rnd = new Random();

        public void SaveParameter(object o)
        {
            if(SelectedItem.type == NodeTypes.master)
            {
                ((RootItem)SelectedItem).ItemName = (o as ItemProperty).PropertyValue;
            }
           
        }

        private void FillRootProp(RootItem root)
        {

            Properties.Add(new ItemProperty() { PropertyName = root.GetType().GetProperty("ItemName").Name, PropertyValue = root.GetType().GetProperty("ItemName").GetValue(root).ToString()});//root.ItemName });
        }

        private void FillPortProp(PortItem port)
        {
            Properties.Add(new ItemProperty() { PropertyName = port.GetType().GetProperty("ItemName").Name, PropertyValue = port.GetType().GetProperty("ItemName").GetValue(port).ToString() });
            Properties.Add(new ItemProperty() { PropertyName = port.GetType().GetProperty("Baud").Name, PropertyValue = port.GetType().GetProperty("Baud").GetValue(port).ToString() });
        }

        public ServersTree ServersTree { get; private set; }

        public MainViewModel()
        {
            
            memoryMap = new Device();
            //MasterNode = new ObservableCollection<INode>();
            //RootItem mainItem = new RootItem();
            //mainItem.ItemName = "Master Node";
            ////mainItem.Children.Add(new DummyNode());
            //MasterNode.Add(mainItem);
            ServersTree = new ServersTree();
        }

        public void TreeSelectionChanged(object o)
        {
            INode node = o as INode;
            if(node.type == NodeTypes.master)
            {

            }
        }

        public void RandomizeData()
        {
            Random rnd = new Random();
            for (int index = 0; index < 10; index++)
            {
                memoryMap.AddHoldingRegister(new Register<UInt16>((UInt16)index) { Value = (UInt16)rnd.Next(0x00, 0xFFFF) });
            }

            for (int index = 0; index < 10; index++)
            {
                memoryMap.AddInputRegister(new Register<UInt16>((UInt16)index) { Value = (UInt16)rnd.Next(0x00, 0xFFFF) });
            }
        }

        public void OpenPort()
        {
            
            serialPort = new SerialComm(SelectedPort, SelectedBaudRate, SelectedParity, SelectedDataBits, SelectedStopBits);
            cts = new CancellationTokenSource();
            try
            {
                slave = new Slave(DeviceAddress, serialPort, memoryMap, cts.Token);
            }
            catch (Exception ex)
            {
            }
            
        }

        public void ClosePort()
        {
            cts.Cancel();
        }



        public void mnuOpenClick()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                //mainTextBox.Document.Blocks.Clear();
                currentFile = openFileDialog.FileName;
                System.IO.StreamReader myRead = new System.IO.StreamReader(currentFile, System.Text.Encoding.GetEncoding(1251));
                //mainTextBox.AppendText(myRead.ReadToEnd());
                myRead.Close();
            }
        }

        public void mnuSaveClick()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveDialog.ShowDialog() == true)
            {
                currentFile = saveDialog.FileName;
                System.IO.StreamWriter myWrite = new System.IO.StreamWriter(currentFile, false, System.Text.Encoding.GetEncoding(1251));

                //var textRange = new TextRange(mainTextBox.Document.ContentStart, mainTextBox.Document.ContentEnd);

                //myWrite.Write(textRange.Text);
                myWrite.Close();
            }
        }

        public void mnuExitClick()
        {
            //this.Close();
        }

        public void AddPort(LocalHostNode o)
        {
            o.Children.Add(new PortNode(o));
        }

        public void DeletePort(PortNode o)
        {
            o.Owner.Children.Remove(o);
        }

        public void AddDevice(PortNode o)
        {
            o.Children.Add(new DeviceNode(o));
        }

        public void DeleteDevice(DeviceNode o)
        {
            o.Owner.Children.Remove(o);
        }

        public void AddTag(DeviceNode o)
        {
            o.Children.Add(new TagNode(o));
        }

        public void DeleteTag(TagNode o)
        {
           o.Owner.Children.Remove(o);
        }

        #region TreeView
        // INotifyPropertyChanged

        private string oldPortName = string.Empty;

        public void RenamePort(PortNode sender)
        {
            oldPortName = sender.Name;
            sender.IsInEditMode = true;
        }

        public void RenamePortComplete(PortNode sender, string name, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                sender.ChangeName(name);
                sender.IsInEditMode = false;
            }
            if(e.Key == Key.Escape)
            {
                sender.ChangeName((string)oldPortName);
                sender.IsInEditMode = false;
            }
        }

        public void RenamePortComplete(PortNode sender, string name)
        {
            sender.ChangeName(name);
            sender.IsInEditMode = false;
        }
        #endregion TreeView
    }
}
