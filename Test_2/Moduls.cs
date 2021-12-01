using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    [Serializable]
    public class Moduls
    {
        public bool Enable { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public string UnitMeas { get; set; }
        public int Precision { get; set; }
        public int Discret { get; set; }
        public string NameProtocol { get; set; }
        public int Massa { get; set; }
        public bool Stabil { get; set; }
        public string StMassa { get; set; }
        public string StState { get; set; }
        public int RxPacket { get; set; }
        public int RxByte { get; set; }
        public int TxPacket { get; set; }
        public int TxByte { get; set; }
        public string WeightIndicatorPluginName { get; set; }
        public string SerialPort { get; set; }
        public string SerialPort_StState { get; set; }
    }
}
