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

        public IEnumerable<Folder> GetAllFoldersByUserId(int userId)
        {
            var folderList = _context.Folder.Where(folder => folder.UserId == userId).ToList();
            folderList.ForEach(folder => folder.Notes = _context.Note.Where(note => note.FolderId == folder.Id).ToList());

            return folderList;
        }

        public Folder GetFolderById(int id)
        {
            Folder folder = _context.Folder.Where(folder => folder.Id == id).FirstOrDefault();
            if(folder != null)
            {
                folder.Notes = _context.Note.Where(note => note.FolderId == folder.Id).ToList();
            }
            return folder;
        }

        public Folder GetUserFolderById(int userId, int id)
        {
            Folder folder = _context.Folder.Where(folder => folder.Id == id && folder.UserId == userId).FirstOrDefault();
            if(folder != null)
            {
                folder.Notes = _context.Note.Where(note => note.FolderId == folder.Id && note.UserId == userId).ToList();
            }
            return folder;
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