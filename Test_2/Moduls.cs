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
        public string Name { get; set; }
        public bool Enable { get; set; }
        public string StateName { get; set; }
        public string StState { get; set; }
        public string NameProtocol { get; set; }
        public string UnitMeas { get; set; }
        public int Massa { get; set; }
        public string StMassa { get; set; }
        public bool Stabil { get; set; }
        public bool modeAuto { get; set; }
        public string RxPacket { get; set; }
        public string WIStState { get; set; }
        public string WIStateName { get; set; }
        public string SPStState { get; set; }
        public int Precision { get; set; }
        public string Discret { get; set; }
        public string StTypScale { get; set; }
        public string TypScaleCaption { get; set; }
        public string TimeWatchdog { get; set; }
    }
}
