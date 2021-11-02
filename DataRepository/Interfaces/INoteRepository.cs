using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface INoteRepository : IBaseRepository
    {
        IEnumerable<Note> GetAllNotes(int userId);
        IEnumerable<Note> GetAllPublicOrUserNotes(int userId);
        Note GetNoteById(int id);
        Note GetPublicOrUserNoteById(int userId, int id);
        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);


    }
}