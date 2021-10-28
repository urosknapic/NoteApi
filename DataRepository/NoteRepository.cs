using System.Collections.Generic;
using NoteApi.Models;

namespace NoteApi.Data
{
    public class NoteRepository : INoteRepository
    {
        public IEnumerable<Note> GetAllNotes()
        {
            var noteList = new List<Note>(){
                new Note { Id = 1, Name = "Test Note 1"},
                new Note { Id = 2, Name = "Test Note 2"},
                new Note { Id = 3, Name = "Test Note 3"}
            };
            return noteList;
        }

        public Note GetNoteById()
        {
            return new Note
            {
                Id = 1,
                Name = "Test Note 1"
            };
        }
    }
}