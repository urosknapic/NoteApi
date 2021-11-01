using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IContentNoteRepository : IBaseRepository
    {
        IEnumerable<ContentNote> GetAllContentNotes();
        ContentNote GetContentNoteById(int id);
        void CreateContentNote(ContentNote contentNote);
        void UpdateContentNote(ContentNote contentNote);
        void DeleteContentNote(ContentNote contentNote);
    }
}