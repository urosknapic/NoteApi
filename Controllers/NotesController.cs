using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{id}", Name = "GetNoteById")]
        public ActionResult<NoteReadDto> GetNoteById(int id)
        {
            var noteItem = _noteRepository.GetNoteById(id);

            if (noteItem == null)
            {
                return NoContent();
            }

            return Ok(_noteMapper.Map<NoteReadDto>(noteItem));
        }

        [HttpPost]
        public ActionResult<NoteReadDto> CreateNote(NoteCreateDto createDto)
        {
            var note = _noteMapper.Map<Note>(createDto);
            note.CreatedAt = DateTime.Now;

            _noteRepository.CreateNote(note);
            _noteRepository.SaveChanges();

            var noteDto = _noteMapper.Map<NoteReadDto>(note);

            return CreatedAtRoute("GetNoteById", new { Id = noteDto.Id }, noteDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, NoteUpdateDto updateDto)
        {
            var noteFromRepository = _noteRepository.GetNoteById(id);

            if (noteFromRepository == null)
            {
                return NotFound();
            }

            _noteMapper.Map(updateDto, noteFromRepository);

            _noteRepository.UpdateNote(noteFromRepository);
            _noteRepository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialNoteUpdate(int id, JsonPatchDocument<NoteUpdateDto> patchNote)
        {
            var noteFromRepository = _noteRepository.GetNoteById(id);

            if (noteFromRepository == null)
            {
                return NotFound();
            }

            var noteUpdaPatch = _noteMapper.Map<NoteUpdateDto>(noteFromRepository);
            patchNote.ApplyTo(noteUpdaPatch, ModelState);

            if (!TryValidateModel(noteUpdaPatch))
            {
                return ValidationProblem(ModelState);
            }

            _noteMapper.Map(noteUpdaPatch, noteFromRepository);

            _noteRepository.UpdateNote(noteFromRepository);
            _noteRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            var noteFromRepository = _noteRepository.GetNoteById(id);

            if (noteFromRepository == null)
            {
                return NotFound();
            }

            _noteRepository.DeleteNote(noteFromRepository);
            _noteRepository.SaveChanges();

            return NoContent();
        }
    }
}