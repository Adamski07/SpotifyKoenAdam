using SpotifyAdamKoen.Classes;
using System.ComponentModel;
using System.Windows.Controls;

namespace SpotifyAdamKoen.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private static MainWindowViewModel _mainInstance;

        public static MainWindowViewModel MainInstance
        {
            get
            {
                if (_mainInstance == null)
                {
                    _mainInstance = new MainWindowViewModel();
                }
                return _mainInstance;
            }
        }

        private ContentControl _currentView;

        public ContentControl CurrentView
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
