using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace synchronizer.Models
{
    public class VideoContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private MediaSource? _fileSource;

        public MediaSource? FileSource 
        {
            get => _fileSource;
            set
            {
                _fileSource = value;
                OnPropertyChanged(nameof(FileSource));
                OnPropertyChanged(nameof(FileChosen));
            }
        }

        public bool FileChosen
        {
            get
            {
                return FileSource is not null;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
