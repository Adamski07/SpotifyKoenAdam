using System;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;

namespace SpotifyAdamKoen.ViewModels.SongViewModels
{
    internal class SongCreateViewModel : NotifyPropertyChanged
    {
        private string artist;
        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                RaisePropertyChanged(nameof(Artist));
            }
        }

        private string genre;
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                RaisePropertyChanged(nameof(Genre));
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

        private int durationInSeconds;
        public int DurationInSeconds
        {
            get => durationInSeconds;
            set
            {
                durationInSeconds = value;
                RaisePropertyChanged(nameof(DurationInSeconds));
            }
        }

        public ICommand SaveSongCommand { get; set; }

        public SongCreateViewModel()
        {
            SaveSongCommand = new RelayCommand(SaveSong);
        }

        private void SaveSong(object obj)
        {
            if (string.IsNullOrWhiteSpace(Artist) || string.IsNullOrWhiteSpace(Genre) || ReleaseDate == default)
            {
                SaveMessage = "All fields are required.";
                return;
            }

            if (DurationInSeconds <= 0)
            {
                SaveMessage = "Duration must be a positive value.";
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

            SongRepository.Songs.Add(newSong);
            SongRepository.SaveSongsToJson();
            SaveMessage = "Song saved successfully!";
        }

        private int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next(10000, 99999);
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
    }
}
