using System;
using System.Collections.Generic;
using System.Linq;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class MYSQLNoteRepository : INoteRepository
    {
        private NoteDbContext _context;

        public MYSQLNoteRepository(NoteDbContext noteContext)
        {
            _context = noteContext;
        }

        public void CreateNote(Note note)
        {
            IfNullThrowArgumentException(note);
            _context.Note.Add(note);
        }

        public IEnumerable<Note> GetAllNotes(int userId)
        {
            return _context.Note.ToList();
        }

        public IEnumerable<Note> GetAllPublicOrUserNotes(int userId)
        {
            return _context.Note.ToList().Where(note => note.UserId == userId || note.TypeId == 2);
        }
        
        public Note GetNoteById(int id)
        {
            return _context.Note.Where(data => data.Id == id).FirstOrDefault();
        }

        public Note GetPublicOrUserNoteById(int userId, int id)
        {
            return _context.Note.Where(data => (data.UserId == userId && data.Id == id && data.TypeId == 1) || (data.Id == id && data.TypeId == 2)).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateNote(Note note)
        {
            _context.Note.Update(note);
        }
        public void DeleteNote(Note note)
        {
            IfNullThrowArgumentException(note);
            _context.Note.Remove(note);
        }

        private void IfNullThrowArgumentException(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
        }
    }
}