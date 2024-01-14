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
            string jsonFileName = "albums.json";
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);

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
                string jsonFileName = "albums.json";
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);


                string jsonContent = JsonConvert.SerializeObject(Albums, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
