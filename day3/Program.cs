using System;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace day3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var file = System.IO.File.OpenRead("input.txt");
            using var fileStream = new StreamReader(file);
            
            var content = (await fileStream.ReadToEndAsync()).Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            // Part One
            int[] gammaRateArr = new int[12];

            foreach (var item in content)
            {
                for (var i = 0; i < 12; i++)
                {
                    int parsedVal = item[i] == '0' ? -1 : 1;

                    gammaRateArr[i] += parsedVal;
                }
            }

            StringBuilder gammaRate = new StringBuilder();
            StringBuilder epsilonRate = new StringBuilder();
            foreach (var item in gammaRateArr)
            {
                gammaRate.Append(item > 0 ? '1' : '0');
                epsilonRate.Append(item <= 0 ? '1' : '0');
            }
            
            var gamma = Convert.ToUInt32(gammaRate.ToString(), 2);
            var eps = Convert.ToInt32(epsilonRate.ToString(), 2);

            Console.WriteLine(gamma * eps);

            // Part Two
            Func<IEnumerable<string>, IEnumerable<string>, bool> o2Comparator = (ones, zeros) => ones.Count() > zeros.Count() || (ones.Count() == zeros.Count());
            var o2 = Convert.ToUInt32(GetResultedCollection(content, 0, o2Comparator).First(), 2);

            Func<IEnumerable<string>, IEnumerable<string>, bool> co2Comparator = (ones, zeros) => ones.Count() < zeros.Count() || ((ones.Count() == zeros.Count() && false));
            var co2 = Convert.ToUInt32(GetResultedCollection(content, 0, co2Comparator).First(), 2);

            Console.WriteLine(o2 * co2);
        }

        private static string[] GetResultedCollection(IEnumerable<string> collection,
            int index,
            Func<IEnumerable<string>, IEnumerable<string>, bool> comparator)
        {
            if(collection.Count() == 1)
            {
                return collection.ToArray();
            }

            var zeros = collection.Where( x => x[index] == '0');
            var ones = collection.Where( x => x[index] == '1');

            if(comparator(ones, zeros)) {
                return GetResultedCollection(ones, index + 1, comparator);
            }
            else {
                return GetResultedCollection(zeros, index + 1, comparator);
            }

        }
    }
}
