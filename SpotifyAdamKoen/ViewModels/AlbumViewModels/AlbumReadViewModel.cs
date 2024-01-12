using SpotifyAdamKoen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotifyAdamKoen.ViewModels.AlbumViewModels
{
    internal class AlbumReadViewModel
    {
        public ICommand NavigateToAlbumCreateCommand { get; set; }

        public AlbumCreateView AlbumCreateView;

        public AlbumReadViewModel()
        {
            AlbumCreateView = new AlbumCreateView();
            NavigateToAlbumCreateCommand = new RelayCommand(NavigateToSongCreate);
        }

        private void NavigateToSongCreate(object obj)
        {
            MainWindowViewModel.Instance.CurrentView.Content = AlbumCreateView;
        }
    }
}
