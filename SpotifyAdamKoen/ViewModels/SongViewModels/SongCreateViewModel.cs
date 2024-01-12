using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;

namespace SpotifyAdamKoen.ViewModels.SongViewModels
{
    internal class SongCreateViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Song> songs;

        public ObservableCollection<Song> Songs
        {
            get => songs;
            set
            {
                songs = value;
                RaisePropertyChange(nameof(Songs));
            }
        }

        private string artist;
        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                RaisePropertyChange(nameof(Artist));
            }
        }

        private string genre;
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                RaisePropertyChange(nameof(Genre));
            }
        }

        private DateTime releaseDate = DateTime.Now;
        public DateTime ReleaseDate
        {
            get => releaseDate;
            set
            {
                releaseDate = value;
                RaisePropertyChange(nameof(ReleaseDate));
            }
        }

        private int durationInSeconds;
        public int DurationInSeconds
        {
            get => durationInSeconds;
            set
            {
                durationInSeconds = value;
                RaisePropertyChange(nameof(DurationInSeconds));
            }
        }

        private string saveMessage;
        public string SaveMessage
        {
            get => saveMessage;
            set
            {
                saveMessage = value;
                RaisePropertyChange(nameof(SaveMessage));
            }
        }

        public ICommand SaveSongCommand { get; set; }

        public SongCreateViewModel()
        {
            LoadSongs();

            SaveSongCommand = new RelayCommand(SaveSong);
        }

        private void SaveSong(object obj)
        {
            // Ensure Songs collection is initialized
            if (Songs == null)
            {
                Songs = new ObservableCollection<Song>();
            }

            // Validate input fields
            if (string.IsNullOrWhiteSpace(Artist) || string.IsNullOrWhiteSpace(Genre) || ReleaseDate == default)
            {
                SaveMessage = "All fields are required.";
                return;
            }

            if (DurationInSeconds <= 0) 
            {
                SaveMessage = "duration must be a positive value.";
                return;
            }

            var newSong = new Song
            {
                Id = GenerateRandomId(),
                Artist = Artist,
                Genre = Genre,
                ReleaseDate = ReleaseDate,
                DurationInSeconds = DurationInSeconds
            };

            Songs.Add(newSong);

            SaveSongsToJson();
            SaveMessage = "Song saved successfully!";
        }


        private int GenerateRandomId()
        {
            // Generate a random 5-digit ID
            Random random = new Random();
            return random.Next(10000, 99999);
        }


        private void LoadSongs()
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

        private void SaveSongsToJson()
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
                saveMessage = ex.ToString();
            }
        }

    }
}
