using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb
{
    public class Playlist
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public List<Song> Items { get; set; }
        public Playlist(string username)
        { 
        Username = username;
            Items = new List<Song>();
        }

    }
}
