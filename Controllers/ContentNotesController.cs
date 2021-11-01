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
    [Route("api/contentNotes")]
    [ApiController]
    public class ContentNotesController : ControllerBase
    {
        private readonly IContentNoteRepository _repository;
        private readonly IMapper _mapper;

        public ContentNotesController(IContentNoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET api/notes
        [HttpGet]
        public ActionResult<IEnumerable<ContentNoteReadDto>> GetAllContentNotes()
        {
            var contentList = _repository.GetAllContentNotes();

            if (contentList == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<ContentNoteReadDto>>(contentList));
        }

        // GET api/notes/{id}
        [HttpGet("{id}", Name = "GetContentNoteById")]
        public ActionResult<ContentNoteReadDto> GetContentNoteById(int id)
        {
            ContentNote contentNoteItem = _repository.GetContentNoteById(id);

            if (contentNoteItem == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<ContentNoteReadDto>(contentNoteItem));
        }

        [HttpPost]
        public ActionResult<ContentNoteReadDto> CreateContentNote(ContentNoteCreateDto createDto)
        {
            ContentNote contentNote = _mapper.Map<ContentNote>(createDto);

            _repository.CreateContentNote(contentNote);
            _repository.SaveChanges();

            var contentNoteDto = _mapper.Map<ContentNoteReadDto>(contentNote);

            return CreatedAtRoute("GetContentNoteById", new { Id = contentNoteDto.Id }, contentNoteDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContentNote(int id, ContentNoteUpdateDto updateDto)
        {
            ContentNote contentNoteItem = _repository.GetContentNoteById(id);

            if (contentNoteItem == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, contentNoteItem);

            _repository.UpdateContentNote(contentNoteItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialNoteUpdate(int id, JsonPatchDocument<ContentNoteUpdateDto> patchNote)
        {
            ContentNote contentNoteItem = _repository.GetContentNoteById(id);

            if (contentNoteItem == null)
            {
                return NotFound();
            }

            var contentNoteUpdaPatch = _mapper.Map<ContentNoteUpdateDto>(contentNoteItem);
            patchNote.ApplyTo(contentNoteUpdaPatch, ModelState);

            if (!TryValidateModel(contentNoteUpdaPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(contentNoteUpdaPatch, contentNoteItem);

            _repository.UpdateContentNote(contentNoteItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteNote(int id)
        {
            ContentNote contentNoteItem = _repository.GetContentNoteById(id);

            if (contentNoteItem == null)
            {
                return NotFound();
            }

            _repository.DeleteContentNote(contentNoteItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}