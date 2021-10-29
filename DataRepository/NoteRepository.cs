using System.Collections.Generic;
using NoteApi.Models;

namespace NoteApi.Data
{
    public class NoteRepository : INoteRepository
    {
        public IEnumerable<NoteModel> GetAllNotes()
        {
            var noteList = new List<NoteModel>(){
                new NoteModel { Id = 1, Title = "Test Note 1"},
                new NoteModel { Id = 2, Title = "Test Note 2"},
                new NoteModel { Id = 3, Title = "Test Note 3"}
            };
            return noteList;
        }

        public NoteModel GetNoteById(int id)
        {
            return null;
        }
    }
}