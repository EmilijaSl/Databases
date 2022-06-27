using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FileRepository : IFileRepository
    {


        private readonly FileContext _context;
        public FileRepository()
        {
            _context = new FileContext();

        }

        public Folder RetrieveFolder(string path)
        {
            var dbFolder = _context.Folders.Include(f => f.Files).SingleOrDefault(a => a.Path == path);
            return dbFolder;
        }

        public void UpdateDbFiles(Folder folder)
        {

            var dbFolder = _context.Folders.Include(i => i.Files).FirstOrDefault(a => a.Path == folder.Path);

            if (dbFolder is not null)
            {
                var filesToAdd = new List<LocalFile>();
                var filesToRemove = new List<LocalFile>();


                foreach (var item in dbFolder.Files)
                {
                    if (folder.Files.All(a => a.FullPath != item.FullPath))
                    {
                        filesToRemove.Add(item);

                    }
                }

                foreach (var item in folder.Files)
                {
                    if (dbFolder.Files.All(a => a.FullPath != item.FullPath))
                    {
                        filesToAdd.Add(item);
                    }
                }

                foreach (var item in filesToRemove)
                {
                    dbFolder.Files.Remove(item);
                }
                dbFolder.Files.AddRange(filesToAdd);

            }
            else
            {
                AddFolder(folder);
            }
            _context.SaveChanges();
        }

        public void AddFolder(Folder folder)
        {

            _context.Folders.Add(folder);
        }
    }
}
