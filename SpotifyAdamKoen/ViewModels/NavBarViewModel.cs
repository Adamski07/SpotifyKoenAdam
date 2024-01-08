using System;
using System.Windows.Input;
using CSharpLes42;
using SpotifyAdamKoen;
using SpotifyAK.Classes;

namespace SpotifyAdamKoen.ViewModels
{
    public class NavBarViewModel : NotifyPropertyChanged
    {
        public ICommand NavigateToSongCommand { get; private set; }
        public ICommand NavigateToAlbumCommand { get; private set; }

        public NavBarViewModel()
        {
            NavigateToSongCommand = new RelayCommand(NavigateToSong);
            NavigateToAlbumCommand = new RelayCommand(NavigateToAlbum);
        }

        private void NavigateToSong(object obj)
        {
            MainWindowViewModel.Instance.CurrentView = new SongView();
        }

        private void NavigateToAlbum(object obj)
        {
            MainWindowViewModel.Instance.CurrentView = new AlbumView();
        }
    }
}
