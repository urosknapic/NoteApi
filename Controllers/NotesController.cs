using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace NoteApi.Controllers
{
    [Authorize]
    [Route("api/users/notes")]
    [ApiController]
    public class NotesController : MainController
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFolderRepository _folderRepository;
        private readonly IMapper _noteMapper;

        private readonly string _wrongUserOrPassword = "Wrong username or password";
        private readonly string _folderDoesNotExist = "Folder does not exist";

        public NotesController(INoteRepository noteRepository, IUserRepository userRepository, IFolderRepository folderRepository, IMapper noteMapper)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
            _folderRepository = folderRepository;
            _noteMapper = noteMapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<NoteReadDto>> GetAllNotes()
        {
            if (InnerUser == null)
            {
                return Unauthorized(_wrongUserOrPassword);
            }

            var noteList = _noteRepository.GetAllPublicOrUserNotes(InnerUser.Id);

            if (noteList == null)
            {
                return NoContent();
            }

            return Ok(noteList);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetNoteById")]
        public ActionResult<NoteReadDto> GetNoteById(int id)
        {
            if (InnerUser == null)
            {
                return Unauthorized(_wrongUserOrPassword);
            }

            Note noteItem = _noteRepository.GetPublicOrUserNoteById(InnerUser.Id, id);

            if (noteItem == null)
            {
                return NoContent();
            }

            return Ok(_noteMapper.Map<NoteReadDto>(noteItem));
        }

        [HttpPost]
        public ActionResult<NoteReadDto> CreateNote(NoteCreateDto createDto)
        {
            if (InnerUser == null)
            {
                return Unauthorized(_wrongUserOrPassword);
            }

            var folderItem = _folderRepository.GetFolderById(createDto.FolderId);
            if(folderItem == null)
            {
                return BadRequest(_folderDoesNotExist);
            }

            Note noteItem = _noteMapper.Map<Note>(createDto);
            _noteRepository.CreateNote(noteItem);
            _noteRepository.SaveChanges();

            var noteDto = _noteMapper.Map<NoteReadDto>(noteItem);

            return CreatedAtRoute("GetNoteById", new { userId = InnerUser.Id, Id = noteDto.Id }, noteDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateNote(int id, NoteUpdateDto updateDto)
        {
            if (InnerUser == null)
            {
                return Unauthorized(_wrongUserOrPassword);
            }

            var folderItem = _folderRepository.GetFolderById(updateDto.FolderId);
            if (folderItem == null)
            {
                return BadRequest(_folderDoesNotExist);
            }

            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, id);

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
            if (InnerUser == null)
            {
                return Unauthorized(_wrongUserOrPassword);
            }

            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, id);

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
            var folderItem = _folderRepository.GetUserFolderById(InnerUser.Id, noteUpdaPatch.FolderId);

            if (folderItem == null)
            {
                return BadRequest(_folderDoesNotExist);
            }

            _noteRepository.UpdateNote(noteItem);
            _noteRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            if (InnerUser == null)
            {
                return Unauthorized(_wrongUserOrPassword);
            }

            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, id);

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