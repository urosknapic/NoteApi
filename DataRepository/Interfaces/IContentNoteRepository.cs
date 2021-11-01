using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IContentNoteRepository : IBaseRepository
    {
        IEnumerable<ContentNote> GetAllContentNotes();
        ContentNote GetContentNoteById(int id);
        void CreateContentNote(ContentNote folder);
        void UpdateContentNote(ContentNote folder);
        void DeleteContentNote(ContentNote folder);
    }
}