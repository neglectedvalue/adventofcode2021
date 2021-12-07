﻿using System;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawData = @"
        3 15  0  2 22
        9 18 13 17  5
        19  8  7 25 23
        20 11 10 24  4
        14 21 16 12  6";
        BingoMatrix matrix = new BingoMatrix(rawData);

            matrix.CheckIfFound(3);
            matrix.PrintDebug();

        }
    }
}
