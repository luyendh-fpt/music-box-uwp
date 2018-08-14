using Linq.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.ViewModel
{
    class ReadAllSongList
    {
        DatabaseHelper Db_Helper = new DatabaseHelper();
        public ObservableCollection<Songs> GetAllSongs()
        {
            return Db_Helper.ReaddAllSongs();
        }
    }
}
