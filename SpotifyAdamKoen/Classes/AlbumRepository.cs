using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
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

        static AlbumRepository()
        {
            LoadAlbums();
        }

        private static string GetJsonFilePath()
        {
            string jsonFileName = "albums.json";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);
        }

        public static void LoadAlbums()
        {
            string jsonFilePath = GetJsonFilePath();

            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                albums = JsonConvert.DeserializeObject<ObservableCollection<Album>>(jsonContent);
            }
            else
            {
                albums = new ObservableCollection<Album>();
            }
        }

        public static void SaveAlbumsToJson()
        {
            try
            {
                string jsonFilePath = GetJsonFilePath();

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
