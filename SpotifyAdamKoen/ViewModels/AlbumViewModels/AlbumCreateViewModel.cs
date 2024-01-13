// AlbumCreateViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;

namespace SpotifyAdamKoen.ViewModels.AlbumViewModels
{
    internal class AlbumCreateViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Album> albums;

        public ObservableCollection<Album> Albums
        {
            get => albums;
            set
            {
                albums = value;
                RaisePropertyChanged(nameof(Albums));
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private DateTime releaseDate = DateTime.Now;
        public DateTime ReleaseDate
        {
            get => releaseDate;
            set
            {
                releaseDate = value;
                RaisePropertyChanged(nameof(ReleaseDate));
            }
        }

        private string artistDetails;
        public string ArtistDetails
        {
            get => artistDetails;
            set
            {
                artistDetails = value;
                RaisePropertyChanged(nameof(ArtistDetails));
            }
        }


        private string saveMessage;
        public string SaveMessage
        {
            get => saveMessage;
            set
            {
                saveMessage = value;
                RaisePropertyChanged(nameof(SaveMessage));
            }
        }

        public ICommand SaveAlbumCommand { get; set; }

        public AlbumCreateViewModel()
        {
            LoadAlbums();

            SaveAlbumCommand = new RelayCommand(SaveAlbum);
        }

        private void SaveAlbum(object obj)
        {
            // Ensure Albums collection is initialized
            if (Albums == null)
            {
                Albums = new ObservableCollection<Album>();
            }

            // Validate input fields
            if (string.IsNullOrWhiteSpace(Title) || ReleaseDate == default || string.IsNullOrWhiteSpace(ArtistDetails))
            {
                SaveMessage = "All fields are required.";
                return;
            }

            var newAlbum = new Album
            {
                Id = GenerateRandomId(),
                Title = Title,
                ReleaseDate = ReleaseDate,
                ArtistDetails = ArtistDetails
            };

            Albums.Add(newAlbum);

            SaveAlbumsToJson();
            SaveMessage = "Album saved successfully!";
        }

        private int GenerateRandomId()
        {
            // Generate a random 5-digit ID
            Random random = new Random();
            return random.Next(10000, 99999);
        }

        private void LoadAlbums()
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

        private void SaveAlbumsToJson()
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
                saveMessage = ex.ToString();
            }
        }
    }
}
