using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface INoteRepository : IBaseRepository
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
}