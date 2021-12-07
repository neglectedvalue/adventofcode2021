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

        public BingoMatrix Play()
        {
            foreach (var number in _inputFlow)
            {
                foreach (var item in _participants)
                {
                    item.CheckIfFound(number);
                    if(item.IsWinnable)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

    }
}