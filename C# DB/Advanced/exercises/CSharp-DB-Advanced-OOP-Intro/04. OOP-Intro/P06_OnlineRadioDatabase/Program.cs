using P06_OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;

namespace P06_OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            int numberOfSongs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string artistName = tokens[0];
                    string songName = tokens[1];
                    string[] time = tokens[2].Split(':');

                    if (int.TryParse(time[0], out int minutes) && int.TryParse(time[1], out int seconds))
                    {
                        songs.Add(new Song(artistName, songName, minutes, seconds));
                        Console.WriteLine("Song added.");
                    }
                    else
                    {
                        throw new InvalidSongLengthException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($@"Songs added: {songs.Count}
Playlist length: {GetPlaylistLength(songs)}");
        }

        private static string GetPlaylistLength(List<Song> songs)
        {
            int totalDuration = 0;
            foreach (var song in songs)
            {
                totalDuration += song.Minutes * 60 + song.Seconds;
            }
            int hours = totalDuration / 3600;
            totalDuration -= hours * 3600;
            int minutes = totalDuration / 60;
            totalDuration -= minutes * 60;
            int seconds = totalDuration;

            return $"{hours}h {minutes}m {seconds}s";
        }
    }
}
