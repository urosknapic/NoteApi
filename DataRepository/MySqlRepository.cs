using System.Collections.Generic;
using System.Linq;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class MySqlRepository : INoteRepository
    {
        private NoteDbContext _context;

        public MySqlRepository(NoteDbContext noteContext)
        {
            _context = noteContext;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Note.ToList();
        }

        public Note GetNoteById(int id)
        {
            return _context.Note.Where(data => data.Id == id).FirstOrDefault();
        }
    }
}