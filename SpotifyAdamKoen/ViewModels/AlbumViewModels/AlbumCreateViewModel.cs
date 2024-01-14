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
                if (AlbumRepository.Albums == null)
                {
                    AlbumRepository.Albums = new System.Collections.ObjectModel.ObservableCollection<Album>();
                }

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

                AlbumRepository.Albums.Add(newAlbum);

                AlbumRepository.SaveAlbumsToJson();
                SaveMessage = "Album saved successfully!";
            }

            private int GenerateRandomId()
            {
                Random random = new Random();
                return random.Next(10000, 99999);
            }

            private void LoadAlbums()
            {
                AlbumRepository.LoadAlbums();
            }
        }
    }
