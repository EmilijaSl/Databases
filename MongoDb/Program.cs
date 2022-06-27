using MongoDb;
using MongoDB.Driver;

var client = new MongoClient("mongodb+srv://EmilijaSliburiene:Vytis2020@cluster0.emno8.mongodb.net/?retryWrites=true&w=majority");
var playListCollection = client.GetDatabase("Playlists").GetCollection<Playlist>("UsersPlaylists");

SelectPlaylist();

Console.WriteLine("Done");
Console.ReadLine();

void InsertPlaylist()
{
    var playlist = new Playlist("Emilija");
    var songs = new List<Song>
    {
    new Song
    {
        Author = "Author ACDC",
        SongName = "Highway to Hell"
    }
    
    };

    playlist.Items = songs;

    playListCollection.InsertOne(playlist);
}

void SelectPlaylist()
{
    var filter = Builders<Playlist>.Filter.Eq("Username", "Emilija"); //sita dalis suskaiciuoja kiek username'as emilija turi dainu
    var result = playListCollection.Find(filter).ToList();
    Console.WriteLine(result.Count);
}
void DeletePlaylist()
{

    var filter = Builders<Playlist>.Filter.Eq("Username", "Emilija");
    playListCollection.DeleteOne(filter);
}
void UpdatePlaylistSong()
{
    var filter = Builders<Playlist>.Filter.Eq("Username", "Emilija");
    var update = Builders<Playlist>.Update.AddToSet<string>("Items", "Song1");
    playListCollection.UpdateMany(filter, update);
}