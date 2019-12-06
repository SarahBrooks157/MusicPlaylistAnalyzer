using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlaylistAnalyzer
{
    class Song
    {
        public string Name;
        public string Artist;
        public string Album;
        public string Genre;
        public int Size;
        public int Time; 
        public int Year;
        public int Plays;

        public Song(string Name, string Artist, string Album, string Genre, int Size, int Time, int Year, int Plays) {
            this.Name = Name;
            this.Artist = Artist;
            this.Album = Album;
            this.Genre = Genre;
            this.Size = Size;
            this.Time = Time;
            this.Year = Year;
            this.Plays = Plays;
        }

        override public string ToString(){
            return String.Format("Song Name: {0}  Artist: {1}  Album: {2}  Genre: {3} " +
                "Size: {4}  Time: {5}  Year: {6}  Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }

    }
}
