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

        public IEnumerable<Note> GetAllPublicOrUserNotes(int userId)
        {
            // if public user then return all public notes
            if (userId == 0)
            {
                var noteListPublic = _context.Note.ToList().Where(note => note.TypeId == 2);
                noteListPublic.ToList().ForEach(note => note.Content = _context.ContentNote.Where(contentNote => contentNote.NoteId == note.Id).ToList());

                return noteListPublic;
            }

            var noteList = _context.Note.ToList().Where(note => note.UserId == userId || note.TypeId == 2);
            noteList.ToList().ForEach(note => note.Content = _context.ContentNote.Where(contentNote => contentNote.NoteId == note.Id).ToList());

            return noteList;
        }

        public Note GetUserNoteById(int userId, int id)
        {
            var noteItem = _context.Note.Where(data => data.UserId == userId && data.Id == id).FirstOrDefault();
            if (noteItem != null)
            {
                noteItem.Content = _context.ContentNote.Where(contextNote => contextNote.NoteId == noteItem.Id).ToList();
            }

            return noteItem;
        }

        public Note GetPublicOrUserNoteById(int userId, int id)
        {
            var noteItem = _context.Note.Where(data => (data.UserId == userId && data.Id == id && data.TypeId == 1) || (data.Id == id && data.TypeId == 2)).FirstOrDefault();
            if (noteItem != null)
            {
                noteItem.Content = _context.ContentNote.Where(contextNote => noteItem.Id == contextNote.NoteId).ToList();
            }

            return noteItem;
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