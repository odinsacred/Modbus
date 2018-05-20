using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;

namespace ModbusSlave.ViewModels
{
    class MainViewModel : Screen
    {

        private const int ROWS = 0x1000;

        private const int COLUMNS = 0x10;

        private int[,] data2D;

        private bool isHeximal;

        private bool isBinary;

        public string Title => "Modbus Slave";

        public string Format => "X";

      

        public bool IsHeximal
        {
            get => this.isHeximal;
            set
            {
                this.isHeximal = value;
                NotifyOfPropertyChange(() => Data2D);
            }
            
        }

        public bool IsBinary
        {
            get => this.isBinary;
            set
            {
                this.isBinary = value;
                NotifyOfPropertyChange(() => Data2D);
            }
        }

        public int[] BaudRate => new int[] { 115200, 19200, 9600 };

        public int[] DataBits => new int[] { 8, 7 };

        public int[] StopBits => new int[] { 0, 1, 2 };

        public Parity[] Parities => new Parity[] { Parity.Even, Parity.Odd, Parity.None };

        public int[,] Data2D
        {
            get => this.data2D;
            
            set
            {
                if (Equals(value, this.data2D))
                {
                    return;
                }

                this.data2D = value;
                NotifyOfPropertyChange(() => Data2D);
            }
        }

        public string[] RowHeaders { get; }

        public string[] ColumnHeaders { get; }

        private Random rnd = new Random();

        public MainViewModel()
        {
            int[,] a = new int[ROWS, COLUMNS];
            this.Data2D = a;
            string[] rowHeaders = new string[COLUMNS];
            for (int i = 0; i < rowHeaders.Length; i++)
            {
                rowHeaders[i] = $"{i:X}";
            }
            string[] columnHeaders = new string[ROWS];
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                columnHeaders[i] = $"{i:X}";
            }
            this.RowHeaders = rowHeaders;
            this.ColumnHeaders = columnHeaders;
            RandomizeData();
        }

        public void RandomizeData()
        {
            int[,] a = new int[ROWS, COLUMNS];

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    a[row, col] = rnd.Next(0, 0xFFFF);
                }
            }
            Data2D = a;
        }
    }
}
