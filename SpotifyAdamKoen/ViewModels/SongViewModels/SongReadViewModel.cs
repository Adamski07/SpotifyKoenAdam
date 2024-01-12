using Newtonsoft.Json;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.IO;


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
    }
}
