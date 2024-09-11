using ExtendedNumerics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SlotMachin
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            List<string[]> bgReelsA = new List<string[]>(5);
            List<int> stopPosition = new List<int>();

            bgReelsA.Add(new string[] { "sym2", "sym7", "sym7", "sym1", "sym1", "sym5", "sym1", "sym4", "sym5", "sym3", "sym2", "sym3", "sym8", "sym4", "sym5", "sym2", "sym8", "sym5", "sym7", "sym2" });
            bgReelsA.Add(new string[] { "sym1", "sym6", "sym7", "sym6", "sym5", "sym5", "sym8", "sym5", "sym5", "sym4", "sym7", "sym2", "sym5", "sym7", "sym1", "sym5", "sym6", "sym8", "sym7", "sym6", "sym3", "sym3", "sym6", "sym7", "sym3" });
            bgReelsA.Add(new string[] { "sym5", "sym2", "sym7", "sym8", "sym3", "sym2", "sym6", "sym2", "sym2", "sym5", "sym3", "sym5", "sym1", "sym6", "sym3", "sym2", "sym4", "sym1", "sym6", "sym8", "sym6", "sym3", "sym4", "sym4", "sym8", "sym1", "sym7", "sym6", "sym1", "sym6" });
            bgReelsA.Add(new string[] { "sym2", "sym6", "sym3", "sym6", "sym8", "sym8", "sym3", "sym6", "sym8", "sym1", "sym5", "sym1", "sym6", "sym3", "sym6", "sym7", "sym2", "sym5", "sym3", "sym6", "sym8", "sym4", "sym1", "sym5", "sym7" });
            bgReelsA.Add(new string[] { "sym7", "sym8", "sym2", "sym3", "sym4", "sym1", "sym3", "sym2", "sym2", "sym4", "sym4", "sym2", "sym6", "sym4", "sym1", "sym6", "sym1", "sym6", "sym4", "sym8" });

            int stake = 1;
            int boardHeight = 3;
            int boardWidth = 5;

            Random rng = new Random();

            List<string[]> slotFace = new List<string[]>(5);

            int stopPos;
            foreach (string[] reel in bgReelsA)
            {
                stopPos = rng.Next(reel.Length); //
                string[] slotFaceReel = selectReels(3, reel, stopPos);
                stopPosition.Add(stopPos);
                slotFace.Add(slotFaceReel);
            }
            Console.Write("Stop Positions: " + string.Join("-", stopPosition));  
            Console.WriteLine();
            Console.WriteLine("Screen:");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 5; col++)
                {

                   Console.Write(" " + slotFace[col][row]);
                }
                Console.WriteLine();
            }
            calculateWin(slotFace, stake, boardHeight, boardWidth);

        }

        private static string[] selectReels(int boardHeight, string[] reel, int position) {
       
        string[] boardReel = new string[boardHeight];
        for(int i = 0; i < boardHeight; i++){
            boardReel[i] = reel[(position + i) % reel.Length];
        }
        return boardReel;
    }


        private static void calculateWin(List<string[]> slotFace, int stake, int boardHeight, int boardWidth)
        {
            BigDecimal totalWin = BigDecimal.Zero;
            List<WinData> winDataList = new List<WinData>();
            
            for (int row = 0; row < boardHeight; row++)
            {

                string symToCompare = slotFace[0][row]; // only first column elements need to be compared.
                bool exists = false; //exit if the symbol is already compared
                foreach (WinData symbol in winDataList)
                {
                    if(symbol.SymbolName == symToCompare)
                    {
                        exists = true;
                    }

                }
                
                if (winDataList.Count !=0 && exists)
                {
                    continue;
                }

                WinData winData = checkForWinCombination(symToCompare, boardHeight, boardWidth, slotFace);
                populateWin(winData, stake);
                if (winData.WinAmount != 0)
                {
                    totalWin += winData.WinAmount;
                    winDataList.Add(winData);
                }
            }
            Console.WriteLine("Total wins: " + totalWin);

            foreach (WinData win in winDataList)
            {

                Console.Write("- Ways win " + String.Join("-", win.PosList) + " " + win.SymbolName + " X" + win.SymCountOnEachCol.Count + ", " + win.WinAmount + ", Ways: " + win.Ways+" "); 
            }

        }


        private static WinData checkForWinCombination(string symToCompare, int boardHeight, int boardWidth, List<string[]> slotFace)
        {

            WinData winData = new WinData();
            List<int> posList = new List<int>();
            Dictionary<int, int> symCountPerColMap = new Dictionary<int, int>();
            int currentCol = 0;

            for (int col = 0; col < boardWidth; col++)
            {
                int symCountPerColumn = 0;
                int pos = col;
                if (col - currentCol > 1)
                    break;
                for (int row = 0; row < boardHeight; row++)
                {
                    String currentSym = slotFace[col][row];

                    if (symToCompare == currentSym)
                    {

                        symCountPerColumn++;
                        if (symCountPerColMap.ContainsKey(col))
                        {
                            symCountPerColMap.Remove(col);
                            symCountPerColMap.Add(col, symCountPerColumn);
                        }
                        else
                        {
                            symCountPerColMap.Add(col, symCountPerColumn);
                        }
                       

                        posList.Add(pos);

                        currentCol = col;
                    }
                    pos += 5;
                }
            }
            winData.PosList = posList;
            winData.SymCountOnEachCol = symCountPerColMap;
            winData.SymbolName = symToCompare;
            return winData;
        }

        private static void populateWin(WinData winData, int stake)
        {
            SlotSymbolWaysPayConfig payOut = (SlotSymbolWaysPayConfig)getPayout()[winData.SymbolName];
            BigDecimal symbolWin;
            int ways;
            if (payOut != null && winData.SymCountOnEachCol.Count >= payOut.MinimumMatch)
            {
                symbolWin = payOut.GetWinAmount(winData.SymCountOnEachCol.Count);

                ways = 1;

                for (int i = 0; i<winData.SymCountOnEachCol.Count; i++) {
                    ways *= (int)winData.SymCountOnEachCol[i];
                }

                BigDecimal finalWin = symbolWin * ways;
                winData.WinAmount = finalWin * stake;
                winData.Ways = ways;
                winData.BasePayout = symbolWin;
                
            }
        }

        private static Dictionary<string, SlotSymbolWaysPayConfig> getPayout()
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
    }
}
