using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMusicBox.Entity;

namespace UWPMusicBox.Services
{
    class SongsService
    {
        public static ObservableCollection<Song> Songs = null;
        public static ObservableCollection<MetaData> MetaItems = null;
        public static ObservableCollection<Song> GetSongs(int page)
        {
            Songs = new ObservableCollection<Song>();
            if (page == 1)
            {
                Songs.Add(new Song
                {
                    Id = 1,
                    Title = "Em Gai Mua",
                    Author = "KV",
                    Singer = "Tram",
                    Description = "Hay",
                    Kind = "nhac tre"
                });

                Songs.Add(new Song
                {
                    Id = 2,
                    Title = "Em Gai Mua 2",
                    Author = "KV",
                    Singer = "Tram",
                    Description = "Hay",
                    Kind = "nhac tre"
                });

                Songs.Add(new Song
                {
                    Id = 3,
                    Title = "Em Gai Mua 3",
                    Author = "KV",
                    Singer = "Tram",
                    Description = "Hay",
                    Kind = "nhac tre"
                });
            }

            if (page == 2)
            {
                Songs.Add(new Song
                {
                    Id = 3,
                    Title = "Em Gai Mua 4",
                    Author = "KV",
                    Singer = "Tram",
                    Description = "Hay",
                    Kind = "nhac tre"
                });

                Songs.Add(new Song
                {
                    Id = 4,
                    Title = "Em Gai Mua 5",
                    Author = "KV",
                    Singer = "Tram",
                    Description = "Hay",
                    Kind = "nhac tre"
                });

                Songs.Add(new Song
                {
                    Id = 5,
                    Title = "Em Gai Mua 6",
                    Author = "KV",
                    Singer = "Tram",
                    Description = "Hay",
                    Kind = "nhac tre"
                });

            }

            MetaItems = new ObservableCollection<MetaData>();

            MetaItems.Add(new MetaData
            {
                Page = 1,
                From = 1,
                To = 3,
                Limit = 3,
                Total = 6,
                TotalPage = 2
            });

            MetaItems.Add(new MetaData
            {
                Page = 2,
                From = 1,
                To = 3,
                Limit = 3,
                Total = 6,
                TotalPage = 2
            });

            return Songs;
        }
    }
}
