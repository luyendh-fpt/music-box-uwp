using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Model
{
    class Songs
    {
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthourName { get; set; }
        public string CreationDate { get; set; }

        public Songs()
        {

        }

        public Songs(string name,string authorname)
        {
            Name = name;
            AuthourName = authorname;
            CreationDate = DateTime.Now.ToString();

        }
    }
}
