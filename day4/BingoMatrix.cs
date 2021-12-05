using System;
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

        public BingoMatrix()
        {
            _table = new BingoEntity[6, 6];
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

        public IEnumerable<int> GetCheckedNumbers(){
            for(int x = 1; x < 6; ++x) {
                for(int y = 1; y < 6; ++y) {
                   if(_table[x,y].Checked)
                        yield return _table[x,y].Number;                    
                }
            }
        }

        public IEnumerable<int> GetUncheckedNumbers(){
            for(int x = 1; x < 6; ++x) {
                for(int y = 1; y < 6; ++y) {
                   if(!_table[x,y].Checked)
                        yield return _table[x,y].Number;                    
                }
            }
        }
    }
}