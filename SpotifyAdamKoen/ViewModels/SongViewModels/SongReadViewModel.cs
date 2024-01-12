using SpotifyAdamKoen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotifyAdamKoen.ViewModels.SongViewModels
{
    internal class SongReadViewModel : NotifyPropertyChanged
    {
        public ICommand NavigateToSongCreateCommand { get; set; }

        public SongCreateView SongCreateView;

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
