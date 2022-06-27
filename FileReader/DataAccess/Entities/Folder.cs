using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Folder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<LocalFile> Files { get; set; }
        public List<Folder> Folders { get; set; }
        public Folder(string name, string path)
        {
            Id = Guid.NewGuid();
            Name = name;
            Path = path;
            Files = new List<LocalFile>();
            Folders = new List<Folder>();
        }
        public Folder() { }
    }
}
