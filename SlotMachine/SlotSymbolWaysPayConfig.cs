using ExtendedNumerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachin
{
    internal class SlotSymbolWaysPayConfig
    {

        public int MinimumMatch { get; set; } 

        public List<BigDecimal> WinAmounts { get; set; }

        public SlotSymbolWaysPayConfig(int minimumMatch, List<BigDecimal> winAmounts)
        {
            this.MinimumMatch = minimumMatch;
            this.WinAmounts = winAmounts;
        }

        public BigDecimal GetWinAmount(int matchedColumnsCount)
        {
            if (matchedColumnsCount < MinimumMatch) return 0f;

            if (matchedColumnsCount - MinimumMatch == 0)
            {
                return WinAmounts[0];
            }
            else if (matchedColumnsCount - MinimumMatch == 1)
            {
                return WinAmounts[1];
            }
            else
            {
                return WinAmounts[2];
            }
        }
    }


   
}
