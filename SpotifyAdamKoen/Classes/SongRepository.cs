using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using SpotifyAdamKoen.Models;

namespace SpotifyAdamKoen.Classes
{
    public class SongRepository
    {
        private static ObservableCollection<Song> songs;

        public static ObservableCollection<Song> Songs
        {
            get
            {
                if (songs == null)
                {
                    LoadSongs();
                }
                return songs;
            }
            set
            {
                songs = value;
            }
        }

        static SongRepository()
        {
            SeedDataIfNeeded();
            LoadSongs();
        }

        private static string GetJsonFilePath()
        {
            //Makes the json file path (it stores it in the bin/Debug/net7.0-windows folder).
            string jsonFileName = "songs.json";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);
        }

        public static void LoadSongs()
        {
            string jsonFilePath = GetJsonFilePath();
            if (File.Exists(jsonFilePath))
            {
                //Gets the json file if it exists.
                string jsonContent = File.ReadAllText(jsonFilePath);
                Songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(jsonContent);
            }
            else
            {
                Songs = new ObservableCollection<Song>();
            }
        }

        public static void SaveSongsToJson()
        {
            try
            {
                string jsonFilePath = GetJsonFilePath();
                string jsonContent = JsonConvert.SerializeObject(Songs, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonContent);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void SeedDataIfNeeded()
        {
            // Check if the data file exists, if not, seed the data
            string jsonFilePath = GetJsonFilePath();

            if (!File.Exists(jsonFilePath))
            {
                DataSeeder.SeedData();
            }
        }
    }


}
