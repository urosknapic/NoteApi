using System;
using System.Collections.Generic;
using System.Linq;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class MYSQLContentNoteRepository : IContentNoteRepository
    {
        private NoteDbContext _context;
        public MYSQLContentNoteRepository(NoteDbContext noteContext)
        {
            _context = noteContext;
        }

        public void CreateContentNote(ContentNote contentNote)
        {
            IfNullThrowArgumentException(contentNote);
            _context.Add(contentNote);
        }

        public void DeleteContentNote(ContentNote contentNote)
        {
            IfNullThrowArgumentException(contentNote);
            _context.ContentNote.Remove(contentNote);
        }

        public IEnumerable<ContentNote> GetAllContentNotes()
        {
            return _context.ContentNote.ToList();
        }

        public ContentNote GetContentNoteById(int id)
        {
            return _context.ContentNote.Where(data => data.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateContentNote(ContentNote contentNote)
        {
            _context.ContentNote.Update(contentNote);
        }

        private void IfNullThrowArgumentException(ContentNote contentNote)
        {
            if (contentNote == null)
            {
                throw new ArgumentNullException(nameof(contentNote));
            }
        }
    }
}