using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace NoteApi.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/notes")]
    [ApiController]
    public class NotesController : MainController
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _noteMapper;

        public NotesController(INoteRepository noteRepository, IMapper noteMapper, IUserRepository userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
            _noteMapper = noteMapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<NoteReadDto>> GetAllNotes(int userId)
        {
            var noteList = _noteRepository.GetAllPublicOrUserNotes(userId);

            if (noteList == null)
            {
                return NoContent();
            }

            return Ok(noteList);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetNoteById")]
        public ActionResult<NoteReadDto> GetNoteById(int userId, int id)
        {
            Note noteItem = _noteRepository.GetPublicOrUserNoteById(userId, id);

            if (noteItem == null)
            {
                return NoContent();
            }

            return Ok(_noteMapper.Map<NoteReadDto>(noteItem));
        }

        [HttpPost]
        public ActionResult<NoteReadDto> CreateNote(NoteCreateDto createDto)
        {
            Note noteItem = _noteMapper.Map<Note>(createDto);

            _noteRepository.CreateNote(noteItem);
            _noteRepository.SaveChanges();

            var noteDto = _noteMapper.Map<NoteReadDto>(noteItem);
            
            return CreatedAtRoute("GetNoteById", new { Id = noteDto.Id }, noteDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, NoteUpdateDto updateDto)
        {
            Note noteItem = _noteRepository.GetNoteById(id);

            if (noteItem == null)
            {
                return NotFound();
            }

            _noteMapper.Map(updateDto, noteItem);

            _noteRepository.UpdateNote(noteItem);
            _noteRepository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialNoteUpdate(int id, JsonPatchDocument<NoteUpdateDto> patchNote)
        {
            Note noteItem = _noteRepository.GetNoteById(id);

            if (noteItem == null)
            {
                return NotFound();
            }

            var noteUpdaPatch = _noteMapper.Map<NoteUpdateDto>(noteItem);
            patchNote.ApplyTo(noteUpdaPatch, ModelState);

            if (!TryValidateModel(noteUpdaPatch))
            {
                return ValidationProblem(ModelState);
            }

            _noteMapper.Map(noteUpdaPatch, noteItem);

            _noteRepository.UpdateNote(noteItem);
            _noteRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            Note noteItem = _noteRepository.GetNoteById(id);

            if (noteItem == null)
            {
                return NotFound();
            }

            _noteRepository.DeleteNote(noteItem);
            _noteRepository.SaveChanges();

            return NoContent();
        }
    }
}