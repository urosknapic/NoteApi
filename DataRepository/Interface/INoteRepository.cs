using System.Collections.Generic;
using NoteApi.Models;

namespace NoteApi.Data
{
    public interface INoteRepository
    {
        IEnumerable<NoteModel> GetAllNotes();
        NoteModel GetNoteById(int id);
    }
}