using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Models;

namespace NoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesControllers : ControllerBase
    {
        /*
        CRUD principle: create, read, update, delete
            Api endpoints:
            GET single note; read operation; 200 ok, 400, 404
            GET all resources; read operation; 200, 400, 404
            POST create new post; 201 on created; 401 unauthorized;
            PUT for update
            DELETE for delete note
        */
        // TODO: replace that with service
        private readonly NoteRepository _noteRepository = new NoteRepository();

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