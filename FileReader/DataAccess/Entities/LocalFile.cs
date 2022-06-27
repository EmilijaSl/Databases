using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class LocalFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public string FullPath { get; set; }

        [ForeignKey("Folder")]
        public Guid FolderId { get; set; }

        public Folder Folder { get; set; }
        public LocalFile(string name, double size, string fullPath, Guid folderId)
        {
            Name = name;
            Size = size;
            FullPath = fullPath;
            FolderId = folderId;
        }
        public LocalFile() { }
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Size} bytes\t{FullPath}";
        }

    }
}
