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
using System.Diagnostics;

namespace ModbusSlave.ViewModels
{
   
    class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {

        Slave slave;
        string currentFile;
        SerialComm serialPort;
        //MemoryMap memoryMap;

        CancellationTokenSource cts;

        public string Title => "Modbus Slave";

        public string Format => "X";

        public UInt16 DeviceAddress { get; set; } = 1;

        public string[] AvailablePorts => SerialPort.GetPortNames();

        public string SelectedPort { get; set; } = "COM1";

        public int[] BaudRates => new int[] { 115200, 19200, 9600 };

        public int SelectedBaudRate { get; set; } = 115200;

        public int[] DataBits => new int[] { 8, 7 };

        public int SelectedDataBits { get; set; } = 8;

        public ComPortLib.StopBits[] _StopBits => new ComPortLib.StopBits[] 
        { ComPortLib.StopBits.None, ComPortLib.StopBits.One, ComPortLib.StopBits.Two };

        public ComPortLib.StopBits SelectedStopBits { get; set; } = ComPortLib.StopBits.One;

        public ComPortLib.Parity[] Parities => new ComPortLib.Parity[] 
        { ComPortLib.Parity.Even, ComPortLib.Parity.Odd, ComPortLib.Parity.None };

        public ComPortLib.Parity SelectedParity { get; set; } = ComPortLib.Parity.None;

        public TreeNode SelectedItem { get; set; }


        public string[] RowHeaders { get; }

        public string[] ColumnHeaders { get; }

        private Random rnd = new Random();

        public ServersTree ServersTree { get; private set; }

        public MainViewModel()
        {
            //memoryMap = new MemoryMap();
            ServersTree = new ServersTree();
        }

        List<Slave> listOfSlaves;

        //public void OpenPort()
        //{
            
        //    serialPort = new SerialComm(SelectedPort, SelectedBaudRate, SelectedParity, SelectedDataBits, SelectedStopBits);
        //    cts = new CancellationTokenSource();
        //    try
        //    {
        //        slave = new Slave(DeviceAddress, serialPort, memoryMap, cts.Token);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
            
        //}

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

        public void StartConfig()
        {
            cts = new CancellationTokenSource();
            ServersTree.CreateSlaves(cts.Token);
        }

        public void AddPort(LocalHostViewModel o)
        {
            o.Children.Add(new PortViewModel(o));
        }

        public void DeletePort(PortViewModel o)
        {
            o.Owner.Children.Remove(o);
        }

        public void AddDevice(PortViewModel o)
        {
            MemoryMap memoryMap = new MemoryMap();
            o.Children.Add(new DeviceViewModel(o, memoryMap));
        }

        public void DeleteDevice(DeviceViewModel o)
        {
            o.Owner.Children.Remove(o);
        }

        public void AddTag(DeviceViewModel o)
        {
            o.Children.Add(new TagViewModel(o));
        }

        public void DeleteTag(TagViewModel o)
        {
           o.Owner.Children.Remove(o);
        }

        #region TreeView
        // INotifyPropertyChanged

        #region renamePort
        private string oldPortName = string.Empty;
       
        public void RenamePort(PortViewModel sender)
        {
            oldPortName = sender.Name;
            sender.IsInEditMode = true;
        }

        public void RenamePortComplete(PortViewModel sender, string name, KeyEventArgs e)
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
        #endregion renamePort

        #region renameDevice
        private string oldDeviceName = string.Empty;

        public void RenameDevice(DeviceViewModel sender)
        {
            oldDeviceName = sender.Name;
            sender.IsInEditMode = true;
        }

        public void RenameDeviceComplete(DeviceViewModel sender, string name, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sender.ChangeName(name);
                sender.IsInEditMode = false;
            }
            if (e.Key == Key.Escape)
            {
                sender.ChangeName((string)oldDeviceName);
                sender.IsInEditMode = false;
            }
        }
        #endregion renameDevice

        #region renameTag
        private string oldTagName = string.Empty;

        public void RenameTag(TagViewModel sender)
        {
            oldTagName = sender.Name;
            sender.IsInEditMode = true;
        }

        public void RenameTagComplete(TagViewModel sender, string name, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sender.ChangeName(name);
                sender.IsInEditMode = false;
            }
            if (e.Key == Key.Escape)
            {
                sender.ChangeName((string)oldTagName);
                sender.IsInEditMode = false;
            }
        }
        #endregion renameTag

        public void RenamePortComplete(PortNode sender, string name)
        {
            sender.ChangeName(name);
            sender.IsInEditMode = false;
        }
        #endregion TreeView

        public void ActivateChildView(object view)
        {
            ActivateItem((IScreen)view);
        }
    }
}
