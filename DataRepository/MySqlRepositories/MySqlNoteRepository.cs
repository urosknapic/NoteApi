using System;
using System.Collections.Generic;
using System.Linq;
using NoteApi.Data.Tables;
using NoteApi.Enums;

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

        public IEnumerable<Note> GetAllPublicOrUserNotes(int userId, string searchString, int notesPerPage, int page, SortTypeEnum sort, SortDirectionEnum direction)
        {
            IEnumerable<Note> noteListTmp = null;

            if (userId == 0)
            {
                noteListTmp = _context.Note.ToList().Where(note => note.TypeId == 2); // select only public notes
            }
            else
            {
                noteListTmp = _context.Note.ToList().Where(note => note.UserId == userId || note.TypeId == 2);
            }

            noteListTmp.ToList().ForEach(note => note.Content = _context.ContentNote.Where(contentNote => contentNote.NoteId == note.Id).ToList());

            if (!string.IsNullOrEmpty(searchString))
            {
                noteListTmp = SearchBySearchText(noteListTmp, searchString);
            }

            noteListTmp = SortNotesCollection(noteListTmp, sort, direction);

            if (page >= 1)
            {
                noteListTmp = PaginationCollection(noteListTmp, page, notesPerPage);
            }

            return noteListTmp;
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

        private IEnumerable<Note> SortNotesCollection(IEnumerable<Note> collection, SortTypeEnum sortBy, SortDirectionEnum direction)
        {
            if (sortBy == SortTypeEnum.NoteShareType && direction == SortDirectionEnum.Ascending)
            {
                collection = collection.OrderBy(note => note.TypeId).ToList();
            }
            else if (sortBy == SortTypeEnum.NoteShareType && direction == SortDirectionEnum.Descending)
            {
                collection = collection.OrderByDescending(note => note.TypeId).ToList();
            }

            else if (sortBy == SortTypeEnum.NoteTitle && direction == SortDirectionEnum.Ascending)
            {
                collection = collection.OrderBy(note => note.Title).ToList();
            }
            else if (sortBy == SortTypeEnum.NoteTitle && direction == SortDirectionEnum.Descending)
            {
                collection = collection.OrderByDescending(note => note.Title).ToList();
            }

            return collection;
        }

        private IEnumerable<Note> SearchBySearchText(IEnumerable<Note> collection, string searchString)
        {
            collection = collection.Where(note => note.Content.Where(content => content.Content.Contains(searchString)).Any());

            return collection;
        }

        private IEnumerable<Note> PaginationCollection(IEnumerable<Note> collection, int page, int notesPerPage)
        {
            var skipNotes = (page - 1) * notesPerPage;
            return collection
                .Skip(skipNotes)
                .Take(notesPerPage);
        }
    }
}