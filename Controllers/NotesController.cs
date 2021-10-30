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
        /* TODO:
        CRUD principle: create, read, update, delete
        Api endpoints:
        GET single note; read operation; 200 ok, 400, 404
        GET all resources; read operation; 200, 400, 404
        POST create new post; 201 on created; 401 unauthorized;
        PUT for update
        DELETE for delete note
        */
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
            return Ok(noteItem);
        }
    }
}