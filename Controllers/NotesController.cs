using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _noteMapper;

        public NotesController(INoteRepository noteRepository, IMapper noteMapper)
        {
            _noteRepository = noteRepository;
            _noteMapper = noteMapper;
        }
        // GET api/notes
        [HttpGet]
        public ActionResult<IEnumerable<NoteReadDto>> GetAllNotes()
        {
            var noteList = _noteRepository.GetAllNotes();

            if (noteList == null)
            {
                return NoContent();
            }

            return Ok(_noteMapper.Map<IEnumerable<NoteReadDto>>(noteList));
        }

        // GET api/notes/{id}
        [HttpGet("{id}")]
        public ActionResult<NoteReadDto> GetNoteById(int id)
        {
            var noteItem = _noteRepository.GetNoteById(id);

            if (noteItem == null)
            {
                return NoContent();
            }

            return Ok(_noteMapper.Map<NoteReadDto>(noteItem));
        }
    }
}