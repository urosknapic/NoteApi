using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
    }
}