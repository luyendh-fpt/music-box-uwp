using Linq.Model;
using Linq.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Linq.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        ObservableCollection<Songs> DB_SongList = new ObservableCollection<Songs>();
        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += ReadSongList_Loaded;
        }

        private void ReadSongList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllSongList dbsongs = new ReadAllSongList();
            DB_SongList = dbsongs.GetAllSongs();//Get all DB contacts    
            if (DB_SongList.Count > 0)
            {
                btnDelete.IsEnabled = true;
            }
            listBoxobj.ItemsSource = DB_SongList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first.    
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxobj.SelectedIndex != -1)
            {
                Songs listitem = listBoxobj.SelectedItem as Songs;//Get slected listbox item contact ID
                Frame.Navigate(typeof(DetailsPage), listitem);
            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelper delete = new DatabaseHelper();
            delete.DeleteAll();//delete all DB contacts
            DB_SongList.Clear();//Clear collections
            btnDelete.IsEnabled = false;
            listBoxobj.ItemsSource = DB_SongList;
        }
        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPage));
        }
    }
}
