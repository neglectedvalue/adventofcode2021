using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace day1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using var streamReader = new StreamReader(System.IO.File.OpenRead("input.txt"));
            var content = await streamReader.ReadToEndAsync();
            var parsedStrings = content.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            //part one
            int[] initialArray = parsedStrings.Select( item => int.Parse(item)).ToArray();
            int counter = 0;
            for(int i = 1; i < initialArray.Length; ++i){
                if(initialArray[i-1] < initialArray[i])
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);

            // part two
            counter = 0;
            for(int i = 0; i < initialArray.Length - 3; ++i){
                var first = initialArray[i] + initialArray[i+1] + initialArray[i+2];
                var second = initialArray[i+1] + initialArray[i+2] + initialArray[i+3];
                if(first < second){
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
