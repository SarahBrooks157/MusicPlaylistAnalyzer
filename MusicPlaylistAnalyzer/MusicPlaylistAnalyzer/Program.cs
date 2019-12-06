using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                SongDataAnalyzer analyzer = new SongDataAnalyzer();

                if (analyzer.ReadFile(args[0]) && analyzer.GenerateReport(args[1]))
                    Console.WriteLine("Report Complete. Data saved in {0}.", args[1]);

                else
                    Console.WriteLine("Report not generated.");
            }

            else
                Console.WriteLine("Incorrect number of arguments. Give an input and output file.");

            Console.ReadLine();
        }
    }
}
