using Newtonsoft.Json;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.IO;
using System;


namespace SpotifyAdamKoen.ViewModels.SongViewModels
{
    internal class SongReadViewModel : NotifyPropertyChanged
    {
        public ICommand NavigateToSongCreateCommand { get; set; }

        public SongCreateView SongCreateView;

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

        public SongReadViewModel()
        {
            SongCreateView = new SongCreateView();
            NavigateToSongCreateCommand = new RelayCommand(NavigateToSongCreate);

            // Load songs from JSON
            LoadSongs();
        }

        private void NavigateToSongCreate(object obj)
        {
            MainWindowViewModel.Instance.CurrentView.Content = SongCreateView;
        }

        private void LoadSongs()
        {
            // Path relative to the application's executable directory
            
     
            if (File.Exists(@"songs.json"))
            {
                string jsonContent = File.ReadAllText(@"songs.json");
                Songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(jsonContent);
            }
            else
            {
                Songs = new ObservableCollection<Song>();
            }
        }
    }
}
