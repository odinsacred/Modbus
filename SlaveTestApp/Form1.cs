using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComportLib;
using ModbusLib;
using System.IO.Ports;
using System.Threading;

namespace SlaveTestApp
{
    public partial class Form1 : Form
    {
        Slave slave;
        SerialComm serialPort;
        Device map;
        CancellationTokenSource cts;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            map = new Device();
            serialPort = new SerialComm("COM1", 19200, Parity.None, 8, StopBits.One);
            cts = new CancellationTokenSource();
            try
            {
                slave = new Slave(0x1, serialPort, map, cts.Token);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
