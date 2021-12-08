using System;
using System.Linq;
using System.Collections.Generic;

namespace day4
{
    public class BingoManager {

        private IList<BingoMatrix> _participants;

        private int[] _inputFlow;

        public BingoManager(string rawData)
        {
            _participants = new List<BingoMatrix>();

            ParseInput(rawData);
        }

        private void ParseInput(string input) {

            var splittedInput = input.Split("@", StringSplitOptions.RemoveEmptyEntries);

            _inputFlow = splittedInput[0]
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select( x => int.Parse(x)).ToArray();

            for (int i = 1; i < splittedInput.Length; i++)
            {
                _participants.Add(new BingoMatrix(splittedInput[i]));
            }
        }

        public void RemoveWiningMatrix(BingoMatrix matrix){
            _participants.Remove(matrix);
        }

        public List<(int, BingoMatrix)> PlayTillEnd(){
            List<(int, BingoMatrix)> winingSeries = new List<(int, BingoMatrix)>();

            foreach (var number in _inputFlow)
            {
                foreach (var item in _participants)
                {
                    if(winingSeries.Any( x => x.Item2 == item))
                        continue;
                    item.CheckIfFound(number);
                    if(item.IsWinnable)
                    {
                        winingSeries.Add((number, item));
                    }
                }
            }

            return winingSeries;
        }


        public (int, BingoMatrix) Play()
        {
            foreach (var number in _inputFlow)
            {
                foreach (var item in _participants)
                {
                    item.CheckIfFound(number);
                    if(item.IsWinnable)
                    {
                        return (number, item);
                    }
                }
            }

            return (-1, null);
        }

    }
}