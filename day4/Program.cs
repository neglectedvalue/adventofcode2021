using System;
using System.Linq;
using System.Threading.Tasks;

namespace day4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var file = System.IO.File.OpenRead("input.txt");
            using var streamReader = new System.IO.StreamReader(file);

            var rawData = await streamReader.ReadToEndAsync();

            BingoManager manager = new BingoManager(rawData);

            // Part One
            /*var (winingNumber, winingMatrix) = manager.Play();

            if(winingNumber != -1)
            {
                var multy = winingMatrix.GetNumbers(false).Sum();
                Console.WriteLine(multy * winingNumber);
            }*/

            // Part Two

            var res = manager.PlayTillEnd();

            res.Last().Item2.PrintDebug();

            var multy = res.Last().Item2.GetNumbers(false).Sum();
            Console.WriteLine(multy * res.Last().Item1);
            
        }
    }
}
