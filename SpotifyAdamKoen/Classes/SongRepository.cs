﻿using System;
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
            get => songs;
            set
            {
                songs = value;
            }
        }

        static SongRepository()
        {
            LoadSongs();
        }

        private static void LoadSongs()
        {
            string jsonFilePath = "C:\\Users\\adam9\\source\\repos\\Adamski07\\SpotifyKoenAdam\\SpotifyAdamKoen\\songs.json";
            if (File.Exists(jsonFilePath))
            {
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
                string jsonFileName = "C:\\Users\\adam9\\source\\repos\\Adamski07\\SpotifyKoenAdam\\SpotifyAdamKoen\\songs.json";
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);

                string jsonContent = JsonConvert.SerializeObject(Songs, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}