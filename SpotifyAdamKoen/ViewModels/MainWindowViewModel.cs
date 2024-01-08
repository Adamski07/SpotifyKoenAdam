using SpotifyAK.Classes;
using System.ComponentModel;

namespace SpotifyAdamKoen.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private static MainWindowViewModel _instance;

        public static MainWindowViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainWindowViewModel();
                }
                return _instance;
            }
        }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainWindowViewModel()
        {
            _currentView = new SongView();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
