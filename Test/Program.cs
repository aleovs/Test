using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        //args[0] - file path
        //args[1] - input x
        //args[2] - input y
        static void Main(string[] args)
        {
            const int ArgsLength = 3;
            if (args.Length == ArgsLength)
            {
                IMicroIndex microIndex = new MicroIndex(args[0]);
                SearchResult searchResult = microIndex.Search(args[1], args[2]);

                Console.WriteLine($"Number of words matching: {searchResult.NumberOfWordsMatching}");
                foreach (var item in searchResult.Positions)
                {
                    Console.WriteLine($"Position matching: {item}");
                }
            }
            else
            {
                Console.WriteLine("Please, specify file path, input x and y");
                return;
            }
        }
    }
}
