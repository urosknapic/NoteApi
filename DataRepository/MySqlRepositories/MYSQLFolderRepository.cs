using System;
using System.Collections.Generic;
using System.Linq;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class MYSQLFolderRepository : IFolderRepository
    {
        private NoteDbContext _context;

        public MYSQLFolderRepository(NoteDbContext noteContext)
        {
            _context = noteContext;
        }
        public void CreateFolder(Folder folder)
        {
            IfNullThrowArgumentException(folder);
            _context.Folder.Add(folder);
        }

        public void DeleteFolder(Folder folder)
        {
            IfNullThrowArgumentException(folder);
            _context.Folder.Remove(folder);
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return _context.Folder.ToList();
        }

        public Folder GetFolderById(int id)
        {
            return _context.Folder.Where(data => data.Id == id).FirstOrDefault();
        }

        public Folder GetUserFolderById(int userId, int id)
        {
            return _context.Folder.Where(data => data.Id == id && data.UserId == userId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateFolder(Folder folder)
        {
            _context.Folder.Update(folder);
        }
        private void IfNullThrowArgumentException(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }
        }
    }
}