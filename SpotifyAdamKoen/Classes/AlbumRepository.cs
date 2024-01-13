// AlbumRepository.cs
using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using SpotifyAdamKoen.Models;

namespace SpotifyAdamKoen.Classes
{
    public static class AlbumRepository
    {
        private static ObservableCollection<Album> albums;

        public static ObservableCollection<Album> Albums
        {
            get
            {
                if (albums == null)
                {
                    LoadAlbums();
                }
                return albums;
            }
            set => albums = value;
        }

        public static void LoadAlbums()
        {
            string jsonFilePath = "C:\\Users\\adam9\\source\\repos\\Adamski07\\SpotifyKoenAdam\\SpotifyAdamKoen\\albums.json";
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                Albums = JsonConvert.DeserializeObject<ObservableCollection<Album>>(jsonContent);
            }
            else
            {
                Albums = new ObservableCollection<Album>();
            }
        }

        public static void SaveAlbumsToJson()
        {
            try
            {
                string jsonFileName = "C:\\Users\\adam9\\source\\repos\\Adamski07\\SpotifyKoenAdam\\SpotifyAdamKoen\\albums.json";
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);

                string jsonContent = JsonConvert.SerializeObject(Albums, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., logging
            }
        }
    }
}
