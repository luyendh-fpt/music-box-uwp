using Linq.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Linq.ViewModel
{
    class DatabaseHelper
    {
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "SongsManager.sqlite"));
        public void CreateDatabase()
        {
            if (!CheckFileExists("SongsManager.sqlite").Result)
            {
                using (var db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
                {
                    db.CreateTable<Songs>();
                }
            }
        }

        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
            }
            return false;
        }

        public void Insert(Songs songs)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                conn.RunInTransaction(() => conn.Insert(songs));
            }
        }

        public Songs ReadSong(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                var song = conn.Query<Songs>("SELECT*FROM Songs WHERE Id = " + id).FirstOrDefault();
                return song;
            }
        }

        public ObservableCollection<Songs> ReaddAllSongs()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
                {
                    List<Songs> Mysongs = conn.Table<Songs>().ToList<Songs>();
                    ObservableCollection<Songs> SongsList = new ObservableCollection<Songs>(Mysongs);
                    return SongsList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Songs songs)
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                var existsong = conn.Query<Songs>("SELECT*FROM Songs WHERE Id = " + songs.Id).FirstOrDefault();
                if(existsong != null)
                {
                    conn.RunInTransaction(() => conn.Update(songs));
                }
            }
        }

        public void DeleteSelected(int id)
        {

            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                var existsong = conn.Query<Songs>("SELECT*FROM Songs WHERE Id = " + id).FirstOrDefault();
                if (existsong != null)
                {
                    conn.RunInTransaction(() => conn.Delete(existsong));
                }
            }
        }

        public void DeleteAll()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
            {
                conn.DropTable<Songs>();
                conn.CreateTable<Songs>();
                conn.Dispose();
                conn.Close();
            }
        }


    }
}
