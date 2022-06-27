using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FileManager : IFileManager
    {

        private readonly IFileRepository fileRepository;

        public List<Folder> Folders { get; set; }
        public List<LocalFile> Files { get; set; }

        public FileManager()
        {
            fileRepository = new FileRepository();
            Files = new List<LocalFile>();
            Folders = new List<Folder>();
        }
        public void RefreshDb(Folder folder)
        {
            fileRepository.UpdateDbFiles(folder);
        }

        public Folder RetrieveDbFolder(string path)
        {
            return fileRepository.RetrieveFolder(path);
        }
        public List<Folder> ReadFolders(string path)
        {
            var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            foreach (var item in directories)
            {
                string name = Path.GetFileName(item);
                string fullPath = Path.GetFullPath(item);
                var folder = new Folder(name, fullPath);
                var files = ReadFiles(folder);
                folder.Files = files;
                Folders.Add(folder);
            }
            return Folders;
        }
        public Folder RetrieveLocalFolder(string path)
        {
            var name = Path.GetFileName(path);
            var folder = new Folder(name, path);
            var files = ReadFiles(folder);
            folder.Folders = ReadFolders(path);
            folder.Files = files;
            return folder;
        }
        private List<LocalFile> ReadFiles(Folder folder)
        {
            var files = Directory.GetFiles(folder.Path);

            foreach (string file in files)
            {
                var fileInfo = new FileInfo(file);
                var name = fileInfo.Name;
                var size = fileInfo.Length;
                var fullPath = Path.GetFullPath(file);
                var folderId = folder.Id;
                var newFile = new LocalFile(name, size, fullPath, folderId);
                Files.Add(newFile);
                folder.Files.Add(newFile);
            }
            return Files;
        }
    }
}
