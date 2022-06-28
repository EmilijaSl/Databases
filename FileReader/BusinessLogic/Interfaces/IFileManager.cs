using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFileManager  //tai, ka privalo implementuoti paveldincios klases
    {
        List<Folder> Folders { get; }
        List<LocalFile> Files { get; }
        void RefreshDb(Folder folder);
        Folder RetrieveDbFolder(string path);
        Folder RetrieveLocalFolder(string path);

    }
}
