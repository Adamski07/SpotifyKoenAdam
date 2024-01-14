using Newtonsoft.Json;
using SpotifyAdamKoen.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpotifyAdamKoen.Classes
{
    internal class DataSeeder
    {
        private static List<Song> GenerateSongsData()
        {
            return new List<Song>
            {
                new Song { Id = 54321, Title = "What They Say", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2023-01-10"), DurationInSeconds = 219 },
                new Song { Id = 67890, Title = "Dance Again", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2020-01-10"), DurationInSeconds = 170 },
                new Song { Id = 23456, Title = "Look at Her Now", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-24"), DurationInSeconds = 163 },
                new Song { Id = 78901, Title = "Lose You to Love Me", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-23"), DurationInSeconds = 206 },
                new Song { Id = 34567, Title = "Ring", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2020-01-10"), DurationInSeconds = 149 },
                new Song { Id = 89012, Title = "Vulnerable", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-24"), DurationInSeconds = 192 },
                new Song { Id = 45678, Title = "People You Know", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-23"), DurationInSeconds = 195 },
                new Song { Id = 90123, Title = "Let Me Get Me", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2020-01-10"), DurationInSeconds = 189 },
                new Song { Id = 56789, Title = "Crowded Room", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-24"), DurationInSeconds = 186 },
                new Song { Id = 23456, Title = "Kinda Crazy", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-23"), DurationInSeconds = 212 },
                new Song { Id = 78901, Title = "Fun", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2020-01-10"), DurationInSeconds = 189 },
                new Song { Id = 34567, Title = "Cut You Off", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-24"), DurationInSeconds = 182 },
                new Song { Id = 89012, Title = "A Sweeter Place", Artist = "Selena Gomez", Genre = "Pop", ReleaseDate = DateTime.Parse("2019-10-23"), DurationInSeconds = 263 },
                new Song { Id = 87654, Title = "Lush Life", Artist = "Zara Larsson", Genre = "Pop", ReleaseDate = DateTime.Parse("2015-06-05"), DurationInSeconds = 201 },
                new Song { Id = 45678, Title = "I Would Like", Artist = "Zara Larsson", Genre = "Pop", ReleaseDate = DateTime.Parse("2016-11-11"), DurationInSeconds = 225 },
                new Song { Id = 23456, Title = "So Good", Artist = "Zara Larsson", Genre = "Pop", ReleaseDate = DateTime.Parse("2017-03-17"), DurationInSeconds = 167 },
                new Song { Id = 87654, Title = "Fireworks", Artist = "Alicia Keys", Genre = "Pop", ReleaseDate = DateTime.Parse("2023-01-10"), DurationInSeconds = 313 },
                new Song { Id = 54321, Title = "Karaoke", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 228 },
                new Song { Id = 78901, Title = "The Resistance", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 225 },
                new Song { Id = 23456, Title = "Over", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 234 },
                new Song { Id = 89012, Title = "Show Me a Good Time", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 210 },
                new Song { Id = 56789, Title = "Up All Night", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 234 },
                new Song { Id = 34567, Title = "Fancy", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 319 },
                new Song { Id = 90123, Title = "Shut It Down [Explicit]", Artist = "Drake", Genre = "Hip-Hop", ReleaseDate = DateTime.Parse("2010-06-15"), DurationInSeconds = 419 }
            };
        }

        private static List<Album> GenerateAlbumsData()
        {
            return new List<Album>
            {
                new Album { Id = 46292, ReleaseDate = DateTime.Parse("2015-06-05"), Title = "So Good", ArtistDetails = "Zara Larsson" },
                new Album { Id = 20976, ReleaseDate = DateTime.Parse("2020-01-10"), Title = "Rare", ArtistDetails = "Selena Gomez" },
                new Album { Id = 95336, ReleaseDate = DateTime.Parse("2010-06-15"), Title = "Thank Me Later", ArtistDetails = "Drake" },
            };
        }

        public static void SeedData()
        {
            SeedSongs();
            SeedAlbums();
        }

        private static void SeedSongs()
        {
            string jsonFileName = "songs.json";
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);

            if (!File.Exists(jsonFilePath))
            {
                List<Song> initialData = GenerateSongsData();

                string jsonData = JsonConvert.SerializeObject(initialData, Formatting.Indented);

                File.WriteAllText(jsonFilePath, jsonData);
            }
        }

        private static void SeedAlbums()
        {
            string jsonFileName = "albums.json";
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);

            if (!File.Exists(jsonFilePath))
            {
                List<Album> initialData = GenerateAlbumsData();

                string jsonData = JsonConvert.SerializeObject(initialData, Formatting.Indented);

                File.WriteAllText(jsonFilePath, jsonData);
            }
        }
    }
}
