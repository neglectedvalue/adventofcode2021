using System;
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

            var win = manager.Play();

            win.PrintDebug();
        }
    }
}
