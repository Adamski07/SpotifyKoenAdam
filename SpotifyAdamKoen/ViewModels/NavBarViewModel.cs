using System;
using System.Windows.Controls;
using System.Windows.Input;
using SpotifyAdamKoen;
using SpotifyAdamKoen.Classes;

namespace SpotifyAdamKoen.ViewModels
{
    public class NavBarViewModel : NotifyPropertyChanged
    {
        public ICommand NavigateToSongCommand { get; private set; }
        public ICommand NavigateToAlbumCommand { get; private set; }

        public SongView song;

        public AlbumView album;

        public NavBarViewModel()
        {
            album = new AlbumView();
            song = new SongView();
            NavigateToSongCommand = new RelayCommand(NavigateToSong);
            NavigateToAlbumCommand = new RelayCommand(NavigateToAlbum);
        }

        private void NavigateToSong(object obj)
        {
            MainWindowViewModel.Instance.CurrentView.Content = song;
        }

        private void NavigateToAlbum(object obj)
        {
            MainWindowViewModel.Instance.CurrentView.Content = album;
        }
    }
}
