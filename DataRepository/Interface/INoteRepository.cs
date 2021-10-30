using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface INoteRepository
    {
        bool SaveChanges();
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
        void CreateNote(Note note);
    }
}