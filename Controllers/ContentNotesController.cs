using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace NoteApi.Controllers
{
    [Authorize]
    [Route("api/users/notes/{noteId}/content")]
    [ApiController]
    public class ContentNotesController : MainController
    {
        private readonly IContentNoteRepository _contentRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        private readonly string _cannotFindNoteContent = "Note content not found";
        private readonly string _cannotFindNote = "Note not found";

        public ContentNotesController(IContentNoteRepository contentRepository, INoteRepository noteRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContentNoteReadDto>> GetAllContentNotes(int noteId)
        {
            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, noteId);
            if (noteItem == null)
            {
                return NotFound();
            }

            var contentList = _contentRepository.GetAllContentNotes(noteItem.Id);
            if (contentList == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<ContentNoteReadDto>>(contentList));
        }

        [HttpPost]
        public ActionResult<ContentNoteReadDto> CreateContentNote(int noteId, ContentNoteCreateDto createDto)
        {
            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, noteId);
            if (noteItem == null)
            {
                return NotFound(_cannotFindNote);
            }

            List<ContentNote> contentList = _contentRepository.GetAllContentNotes(noteItem.Id).ToList();

            if (contentList != null && contentList.Count() > 1 && !noteItem.IsListNote)
            {
                return BadRequest("Can't add more content to the note. It is Text only note");
            }

            ContentNote contentNote = _mapper.Map<ContentNote>(createDto);
            contentNote.NoteId = noteItem.Id;

            _contentRepository.CreateContentNote(contentNote);
            _contentRepository.SaveChanges();

            var contentNoteDto = _mapper.Map<ContentNoteReadDto>(contentNote);

            return CreatedAtRoute("GetNoteById", new { Id = noteItem.Id }, contentNoteDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContentNote(int noteId, int id, ContentNoteUpdateDto updateDto)
        {
            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, noteId);
            if (noteItem == null)
            {
                return NotFound(_cannotFindNote);
            }

            ContentNote contentNoteItem = _contentRepository.GetContentNoteById(id);
            if (contentNoteItem == null)
            {
                return NotFound(_cannotFindNoteContent);
            }

            _mapper.Map(updateDto, contentNoteItem);

            _contentRepository.UpdateContentNote(contentNoteItem);
            _contentRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int noteId, int id)
        {
            Note noteItem = _noteRepository.GetUserNoteById(InnerUser.Id, noteId);
            if (noteItem == null)
            {
                return NotFound(_cannotFindNote);
            }

            ContentNote contentNoteItem = _contentRepository.GetContentNoteById(id);
            if (contentNoteItem == null)
            {
                return NotFound(_cannotFindNoteContent);
            }

            _contentRepository.DeleteContentNote(contentNoteItem);
            _contentRepository.SaveChanges();

            return NoContent();
        }
    }
}