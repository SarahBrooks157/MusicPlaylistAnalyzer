using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    class SongDataAnalyzer
    {
        List<Song> Songs;

        public SongDataAnalyzer() {
            Songs = new List<Song>();
        }

        public bool ReadFile(string file) {
            string line = "";
            int pass = 0;
            List<string> data = new List<string>();

            if (File.Exists(file)) {
                StreamReader sr = new StreamReader(file);
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var split = line.Split('\t');

                        foreach (string s in split)
                            data.Add(s);


                        if (pass != 0 && data.Count != 8)
                        {
                            Console.WriteLine("Line {0} has incorrect amount of values. 8 tab separated values should be in each line. \n" +
                            "Check input file and try again.", pass + 1);
                            return false;
                        }

                        else if (pass != 0)
                        {
                            Song song = new Song(data[0], data[1], data[2], data[3], int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
                            Songs.Add(song);
                        }

                        pass++;
                        data.Clear();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error at line {0}:", pass + 1);

                    if (e is FormatException)
                        Console.WriteLine(e.Message + " Check that values 5 - 8 are integer values.");

                    else 
                        Console.WriteLine(e.Message);
                    
                    return false;
                }

               
                finally
                {
                    sr.Close();
                }
            }
            else {
                Console.WriteLine("Input file does not exist.");
                return false;
            }
            return true;
        }


        public bool GenerateReport(string file) {

            if (File.Exists(file))
            {
                StreamWriter sw = new StreamWriter(file);

                try
                {
                    //How many songs received 200 or more plays?
                    var query1 = from song in Songs
                                 where song.Plays >= 200
                                 select song;

                    sw.WriteLine("Songs with 200 or more plays:");
                    foreach (Song s in query1)
                    {
                        sw.WriteLine(s.ToString());
                    }
                    sw.WriteLine();

                    //How many songs are in the playlist with the Genre of “Alternative”?
                    var query2 = from s in Songs
                                 where s.Genre == "Alternative"
                                 select s;
                    sw.WriteLine("Number of Alternative songs: {0} \n", query2.Count());

                    //How many songs are in the playlist with the Genre of “Hip - Hop / Rap”?
                    var query3 = from s in Songs
                                 where s.Genre == "Hip-Hop/Rap"
                                 select s;
                    sw.WriteLine("Number of Hip-Hop/Rap songs: {0} \n", query3.Count());

                    //What songs are in the playlist from the album “Welcome to the Fishbowl?”
                    var query4 = from s in Songs
                                 where s.Album == "Welcome to the Fishbowl"
                                 select s;

                    sw.WriteLine("Songs from \"Welcome to the Fishbowl\":");
                    foreach (Song s in query4)
                    {
                        sw.WriteLine(s.ToString());
                    }
                    sw.WriteLine();

                    //What are the songs in the playlist from before 1970 ?
                    var query5 = from s in Songs
                                 where s.Year < 1970
                                 select s;

                    sw.WriteLine("Songs from before 1970:");
                    foreach (Song s in query5)
                    {
                        sw.WriteLine(s.ToString());
                    }
                    sw.WriteLine();

                    //What are the song names that are more than 85 characters long?
                    var query6 = from s in Songs
                                 where s.Name.Length > 85
                                 select s.Name;

                    sw.WriteLine("Song names that are more than 85 characters:");
                    foreach (string s in query6)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine();

                    //What is the longest song ? (longest in Time)
                    int maxTime = Songs.Select(s => (s.Time)).Max();

                    var query7 = from s in Songs
                                 where s.Time == maxTime
                                 select s;
                    sw.WriteLine("The longest song is:");
                    foreach (Song s in query7)
                    {
                        sw.WriteLine(s.ToString());
                    }
                    sw.WriteLine();
                }

                catch (Exception e)
                {
                    Console.WriteLine("Exception: at line {0} " + e.Message);
                    return false;

                }
                finally
                {
                    sw.Close();
                }

                return true;
            }

            else
            {
                Console.WriteLine("Given output file does not exist.");
                return false;
            }
        }

    }
}
