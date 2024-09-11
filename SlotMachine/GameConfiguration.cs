using System;
using ExtendedNumerics;
using SlotMachine;

namespace SlotMachine;

public class GameConfiguration
{

            public static int Stake = 1;
            public static int BoardHeight = 3;
            public static int BoardWidth = 5;

     static internal Dictionary<string, SlotSymbolWaysPayConfig> GetPayout()
        {

            Dictionary<string, SlotSymbolWaysPayConfig> payTable = new Dictionary<string, SlotSymbolWaysPayConfig>();

            payTable.Add("sym1", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 1, 2, 3 }));
            payTable.Add("sym2", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 1, 2, 3 }));
                                                                         
            payTable.Add("sym3", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 1, 2, 5 }));
                                                                         
            payTable.Add("sym4", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 2, 5, 10 }));
                                                                         
            payTable.Add("sym5", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 5, 10, 15 }));
            payTable.Add("sym6", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 5, 10, 15 }));
                                                                         
            payTable.Add("sym7", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 5, 10, 20 }));
            payTable.Add("sym8", new SlotSymbolWaysPayConfig(3, new List<BigDecimal> { 10, 20, 50 }));

            return payTable;
        }


         static internal List<string[]> GetReels()
        {

            List<string[]> bgReelsA = new List<string[]>(5);
            
            bgReelsA.Add(new string[] { "sym2", "sym7", "sym7", "sym1", "sym1", "sym5", "sym1", "sym4", "sym5", "sym3", "sym2", "sym3", "sym8", "sym4", "sym5", "sym2", "sym8", "sym5", "sym7", "sym2" });
            bgReelsA.Add(new string[] { "sym1", "sym6", "sym7", "sym6", "sym5", "sym5", "sym8", "sym5", "sym5", "sym4", "sym7", "sym2", "sym5", "sym7", "sym1", "sym5", "sym6", "sym8", "sym7", "sym6", "sym3", "sym3", "sym6", "sym7", "sym3" });
            bgReelsA.Add(new string[] { "sym5", "sym2", "sym7", "sym8", "sym3", "sym2", "sym6", "sym2", "sym2", "sym5", "sym3", "sym5", "sym1", "sym6", "sym3", "sym2", "sym4", "sym1", "sym6", "sym8", "sym6", "sym3", "sym4", "sym4", "sym8", "sym1", "sym7", "sym6", "sym1", "sym6" });
            bgReelsA.Add(new string[] { "sym2", "sym6", "sym3", "sym6", "sym8", "sym8", "sym3", "sym6", "sym8", "sym1", "sym5", "sym1", "sym6", "sym3", "sym6", "sym7", "sym2", "sym5", "sym3", "sym6", "sym8", "sym4", "sym1", "sym5", "sym7" });
            bgReelsA.Add(new string[] { "sym7", "sym8", "sym2", "sym3", "sym4", "sym1", "sym3", "sym2", "sym2", "sym4", "sym4", "sym2", "sym6", "sym4", "sym1", "sym6", "sym1", "sym6", "sym4", "sym8" });


            return bgReelsA;
        }

}
