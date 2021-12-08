using System;
using System.Linq;
using System.Collections.Generic;

namespace day4
{

    public class BingoMatrix {

        protected struct BingoEntity {
            public int Number {get; set;}
            public bool Checked {get; set;}
        }

        /*
        0 0  0  0  0  0  <- X, Y axes are for checked numbers count
        0 1  33 12 55 13
        0 3  8  13 66 35
        0 5  9  99 21 67
        0 6  10 81 76 98
        0 11 44 32 90 42
        */

        private BingoEntity[,] _table;

        public bool IsWinnable { get; private set; }

        private const int WiningResult = 5;

        public BingoMatrix(){}

        public BingoMatrix(string rawData)
        {
            if(string.IsNullOrWhiteSpace(rawData))
                throw new ArgumentException(rawData);

            _table = new BingoEntity[6, 6];

            BuildBingoMatrix(rawData);
        }

        /* rawData exmpl
        3 15  0  2 22
        9 18 13 17  5
        19  8  7 25 23
        20 11 10 24  4
        14 21 16 12  6

        */
        private void BuildBingoMatrix(string rawData){
            string[] rows = rawData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            for (var i = 1; i < 6; i++)
            {
                int[] numbers = rows[i - 1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select( item => int.Parse(item))
                    .ToArray();

                for (var j = 1; j < 6; j++)
                {
                    _table[i, j].Number = numbers[j - 1];
                    _table[i, j].Checked = false;
                }    
            }
        }

        public void PrintDebug(){
            for(int x = 1; x < 6; ++x) {
                for(int y = 1; y < 6; ++y) {
                    string formattedOutput = _table[x,y].Checked ? $"({_table[x,y].Number}) " : $"{_table[x,y].Number} ";
                    Console.Write(formattedOutput);                      
                }
                Console.WriteLine();
            }
        }

        public void CheckIfFound(int number)
        {
            for(int x = 1; x < 6; ++x) {
                for(int y = 1; y < 6; ++y) {
                    if(_table[x,y].Number == number){
                        _table[x,y].Checked = true;
                        _table[x,0].Number += 1;
                        _table[0,y].Number += 1;
                        if(_table[x,0].Number == 5 ||
                         _table[0,y].Number == 5) {
                            IsWinnable = true;
                        }
                    }
                }
            }
        }

        public IEnumerable<int> GetNumbers(bool bingo)
        {
            for(int x = 1; x < 6; ++x) {
                for(int y = 1; y < 6; ++y) {
                   if(_table[x,y].Checked == bingo)
                        yield return _table[x,y].Number;                    
                }
            }
        }

    }
}