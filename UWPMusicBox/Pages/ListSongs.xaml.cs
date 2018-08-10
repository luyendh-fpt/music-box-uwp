using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPMusicBox.Entity;
using UWPMusicBox.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicBox.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSongs : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Song> _songs;
        private Song _selectedSong = null;
        private MetaData _meta;
        public ObservableCollection<MetaData> MetaItems { get; set; }
        public ObservableCollection<Song> Songs
        {
            get => _songs;
            set
            {
                if (value != _songs)
                {
                    _songs = value;
                    OnPropertyChanged();
                }
            }
        }

        public Song SelectedSong
        {
            get => _selectedSong;
            set
            {
                if (value != this._selectedSong)
                {
                    this._selectedSong = value;
                    OnPropertyChanged();
                }
            }
        }

        public MetaData Meta
        {
            get => _meta;
            set
            {
                if (value != this._meta)
                {
                    this._meta = value;
                    OnPropertyChanged();
                }
            }
        }

        public ListSongs()
        {
            if (SongsService.Songs == null)
            {
                SongsService.GetSongs(1);
                Songs = SongsService.Songs;
            }


            MetaItems = SongsService.MetaItems;
            this.InitializeComponent();
        }

        private void Kind_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Songs = SongsService.GetSongs(((MetaData)e.AddedItems[0]).Page);
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedSong = (Song)((StackPanel)sender).Tag;
            if (SelectedSong != null)
            {
                this.SongDetail.Visibility = Visibility.Visible;
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
