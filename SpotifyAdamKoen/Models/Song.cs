using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAdamKoen.Classes;
using System.Windows.Controls;

namespace SpotifyAdamKoen.Models
{
    public class Song : NotifyPropertyChanged
    {
        private static int nextId = 1;

        private int _id;
        public int Id
        {
            get => this._id;
            set
            {
                if (this._id != value)
                {
                    this._id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        private string _artist;
        public string Artist
        {
            get => this._artist;
            set
            {
                this._artist = value;
                RaisePropertyChanged(nameof(Artist));
            }
        }

        private string _genre;
        public string Genre
        {
            get => this._genre;
            set
            {
                this._genre = value;
                RaisePropertyChanged(nameof(Genre));
            }
        }

        private DateTime _releaseDate;
        public DateTime ReleaseDate
        {
            get => this._releaseDate;
            set
            {
                this._releaseDate = value;
                RaisePropertyChanged(nameof(ReleaseDate));
            }
        }

        private int _durationInSeconds;
        public int DurationInSeconds
        {
            get => this._durationInSeconds;
            set
            {
                this._durationInSeconds = value;
                RaisePropertyChanged(nameof(DurationInSeconds));
            }
        }

    }
}