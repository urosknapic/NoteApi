using System.Collections.Generic;
using NoteApi.Models;

namespace NoteApi.Data
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(int id);
    }
}