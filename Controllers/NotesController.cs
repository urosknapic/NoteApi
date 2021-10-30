using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;

namespace NoteApi.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        // GET api/notes
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            var noteList = _noteRepository.GetAllNotes();
            return Ok(noteList);
        }

        // GET api/notes/{id}
        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(int id)
        {
            var noteItem = _noteRepository.GetNoteById(id);

            if (noteItem == null)
            {
                return NoContent();
            }

            return Ok(noteItem);
        }
    }
}