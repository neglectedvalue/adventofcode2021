using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace day2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var file = System.IO.File.OpenRead("input.txt");
            using var streamReader = new StreamReader(file);

            var tokens = (await streamReader.ReadToEndAsync())
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            var pairs = tokens.Select( item => { 
                return (item.Split(' ')[0], int.Parse(item.Split(' ')[1]));
                }
            );

            // Part one
            Console.WriteLine($"Part one : {PartOne(pairs)}");

            // Part two
            Console.WriteLine($"Part two : {PartTwo(pairs)}");

        }

        private static int PartOne(IEnumerable<(string, int)> pairs){
            int forward = 0;
            int depth = 0;

            foreach (var item in pairs)
            {
                switch (item.Item1)
                {
                    case "forward":
                    forward += item.Item2;
                        break;
                    case "down":
                    depth += item.Item2;
                        break;
                    case "up":
                    depth -= item.Item2;
                        break;
                    default:
                        break;
                }
                             
            }

            return forward * depth;
        }

        private static int PartTwo(IEnumerable<(string, int)> pairs){
            int forward = 0;
            int depth = 0;
            int aim = 0;

                        foreach (var item in pairs)
            {
                switch (item.Item1)
                {
                    case "forward":
                    forward += item.Item2;
                    depth += item.Item2 * aim;
                        break;
                    case "down":
                    aim += item.Item2;
                        break;
                    case "up":
                    aim -= item.Item2;
                        break;
                    default:
                        break;
                }
                             
            }

            return forward * depth;
        }

    }
}
