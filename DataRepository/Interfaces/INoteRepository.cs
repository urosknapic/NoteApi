using System.Collections.Generic;
using NoteApi.Data.Tables;
using NoteApi.Enums;

namespace NoteApi.Data
{
    public interface INoteRepository : IBaseRepository
    {
        IEnumerable<Note> GetAllPublicOrUserNotes(int userId, int notesPerPage, int page, SortTypeEnum sort, SortDirectionEnum direction);
        Note GetUserNoteById(int userId, int id);
        Note GetPublicOrUserNoteById(int userId, int id);
        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);


    }
}