using SpotifyAdamKoen.Classes;
using System;
using System.ComponentModel;

namespace SpotifyAdamKoen.Models
{
    public class Album : NotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }


        private DateTime? releaseDate;
        public DateTime? ReleaseDate
        {
            get => releaseDate;
            set
            {
                releaseDate = value;
                RaisePropertyChanged(nameof(ReleaseDate));
            }
        }


        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }


        private string artistDetails;
        public string ArtistDetails
        {
            get { return artistDetails; }
            set
            {
                if (artistDetails != value)
                {
                    artistDetails = value;
                    RaisePropertyChanged(nameof(ArtistDetails));
                }
            }
        }
    }
}
