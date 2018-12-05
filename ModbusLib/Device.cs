using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusLib
{
    public class Device
    {
        private IMemoryMap memoryMap;

        private List<Tag> Tags = new List<Tag>();

        public Device(IMemoryMap  memoryMap)
        {
            this.memoryMap = memoryMap;
        }

        public void AddTag()
        {

        }
    }
}
