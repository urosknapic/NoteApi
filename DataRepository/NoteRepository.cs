using System.Collections.Generic;
using NoteApi.Models;

namespace NoteApi.Data
{
    public class NoteRepository : INoteRepository
    {
        public IEnumerable<NoteModel> GetAllNotes()
        {
            var noteList = new List<NoteModel>(){
                new NoteModel { Id = 1, Name = "Test Note 1"},
                new NoteModel { Id = 2, Name = "Test Note 2"},
                new NoteModel { Id = 3, Name = "Test Note 3"}
            };
            return noteList;
        }

        public NoteModel GetNoteById(int id)
        {
            return null;
        }
    }
}