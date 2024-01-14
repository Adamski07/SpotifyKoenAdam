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

        public AlbumReadViewModel()
        {
            AlbumCreateView = new AlbumCreateView();
            NavigateToAlbumCreateCommand = new RelayCommand(NavigateToAlbumCreate);

            AlbumRepository.LoadAlbums();
        }

        private void NavigateToAlbumCreate(object obj)
        {
            MainWindowViewModel.MainInstance.CurrentView.Content = AlbumCreateView;
        }

        public ObservableCollection<Album> Albums => AlbumRepository.Albums;
    }
}