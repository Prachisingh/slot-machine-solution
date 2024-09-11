# slot-machine-solution

A small project in c sharp that simulates a 5 columns by 3 rows slot machine spin. Type of engine is Pay-way type.

Reelset:
- Band 1: "sym2", "sym7", "sym7", "sym1", "sym1", "sym5", "sym1", "sym4", "sym5", "sym3", "sym2", "sym3", "sym8", "sym4", "sym5", "sym2", "sym8", "sym5", "sym7", "sym2"
- Band 2: "sym1", "sym6", "sym7", "sym6", "sym5", "sym5", "sym8", "sym5", "sym5", "sym4", "sym7", "sym2", "sym5", "sym7", "sym1", "sym5", "sym6", "sym8", "sym7", "sym6", "sym3", "sym3", "sym6", "sym7", "sym3"
- Band 3: "sym5", "sym2", "sym7", "sym8", "sym3", "sym2", "sym6", "sym2", "sym2", "sym5", "sym3", "sym5", "sym1", "sym6", "sym3", "sym2", "sym4", "sym1", "sym6", "sym8", "sym6", "sym3", "sym4", "sym4", "sym8", "sym1", "sym7", "sym6", "sym1", "sym6"
- Band 4: "sym2", "sym6", "sym3", "sym6", "sym8", "sym8", "sym3", "sym6", "sym8", "sym1", "sym5", "sym1", "sym6", "sym3", "sym6", "sym7", "sym2", "sym5", "sym3", "sym6", "sym8", "sym4", "sym1", "sym5", "sym7"
- Band 5: "sym7", "sym8", "sym2", "sym3", "sym4", "sym1", "sym3", "sym2", "sym2", "sym4", "sym4", "sym2", "sym6", "sym4", "sym1", "sym6", "sym1", "sym6", "sym4", "sym8"

The program should display the randomly drawn stop positions (index starting from 0) and visible screen symbols in a nicely formatted way like such:

    Stop Positions: 18, 9, 2, 0, 12
    Screen:
      sym7 sym4 sym7 sym2 sym6
      sym2 sym7 sym8 sym6 sym4
      sym2 sym2 sym3 sym3 sym1

Additionally, implements the winnings calculation for the following paytable:

     Symbol | 3 of a kind | 4 of a kind | 5 of a kind 
    --------|-------------|-------------|-------------
      sym1  |      1      |      2      |      3 
    --------|-------------|-------------|-------------
      sym2  |      1      |      2      |      3 
    --------|-------------|-------------|-------------
      sym3  |      1      |      2      |      5 
    --------|-------------|-------------|-------------
      sym4  |      2      |      5      |      10 
    --------|-------------|-------------|-------------
      sym5  |      5      |      10     |      15 
    --------|-------------|-------------|-------------
      sym6  |      5      |      10     |      15
    --------|-------------|-------------|-------------
      sym7  |      5      |      10     |      20
    --------|-------------|-------------|-------------
      sym8  |      10     |      20     |      50

In Ways slots, winning combinations can typically occur anywhere on the reels as long as the same symbol appears on adjacent reels from left to right.

Winnings should first display the total wins then win details should be listed sequentially. 
Each entry should display ways win with winning positions (index based), the symbol id, the number of matches and the payout. 

Screen index positions:
      sym7 sym4 sym7 sym2 sym6		 0	 1	 2	 3	 4
      sym2 sym7 sym8 sym6 sym4		 5	 6	 7	 8	 9
      sym2 sym2 sym3 sym3 sym1		10	11	12	13	14

Here is another example of a complete result with wins:

    Stop Positions: 0, 11, 1, 10, 14
    Screen:
      sym2 sym2 sym2 sym5 sym1
      sym7 sym5 sym7 sym1 sym6
      sym7 sym7 sym8 sym6 sym1
    Total wins: 11 
    - Ways win 0-1-2, sym2 x3, 1
    - Ways win 5-11-7, sym7 x3, 5
    - Ways win 10-11-7, sym7 x3, 5
