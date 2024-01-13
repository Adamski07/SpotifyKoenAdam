using System.Collections.ObjectModel;
using System.Windows.Input;
using SpotifyAdamKoen.Classes;
using SpotifyAdamKoen.Models;

namespace SpotifyAdamKoen.ViewModels.SongViewModels
{
    internal class SongReadViewModel : NotifyPropertyChanged
    {
        public ICommand NavigateToSongCreateCommand { get; set; }

        public SongCreateView SongCreateView;

        public ObservableCollection<Song> Songs
        {
            get => SongRepository.Songs;
        }

        public SongReadViewModel()
        {
            SongCreateView = new SongCreateView();
            NavigateToSongCreateCommand = new RelayCommand(NavigateToSongCreate);
        }

        private void NavigateToSongCreate(object obj)
        {
            MainWindowViewModel.Instance.CurrentView.Content = SongCreateView;
        }
    }
}
