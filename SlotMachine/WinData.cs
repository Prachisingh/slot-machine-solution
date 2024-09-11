using ExtendedNumerics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachin
{
    internal class WinData
    {

        public List<int> PosList { get; set; }
        public string SymbolName { get; set; }
        public BigDecimal WinAmount { get; set; } = BigDecimal.Zero;

        public int Ways { get; set; }
        public BigDecimal BasePayout { get; set; }

        public Dictionary<int, int> SymCountOnEachCol = new Dictionary<int, int>();
    }
}
