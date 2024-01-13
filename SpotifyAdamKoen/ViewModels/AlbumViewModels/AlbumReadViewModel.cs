// AlbumReadViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;
using System.IO;


namespace SpotifyAdamKoen.ViewModels.AlbumViewModels
{
    internal class AlbumReadViewModel : NotifyPropertyChanged
    {
        public ICommand NavigateToAlbumCreateCommand { get; set; }

        public AlbumCreateView AlbumCreateView;

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

        public AlbumReadViewModel()
        {
            AlbumCreateView = new AlbumCreateView();
            NavigateToAlbumCreateCommand = new RelayCommand(NavigateToAlbumCreate);

            // Load albums from JSON
            LoadAlbums();
        }

        private void NavigateToAlbumCreate(object obj)
        {
            MainWindowViewModel.Instance.CurrentView.Content = AlbumCreateView;
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
    }
}
