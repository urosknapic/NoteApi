using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Controllers
{
    [Authorize]
    [Route("api/users/folders")]
    [ApiController]
    public class FoldersController : MainController
    {
        private readonly IFolderRepository _repository;
        private readonly IMapper _mapper;

        public FoldersController(IFolderRepository noteRepository, IMapper noteMapper)
        {
            _repository = noteRepository;
            _mapper = noteMapper;
        }

        [HttpGet]
        public ActionResult GetAllFolders()
        {
            var foldersList = _repository.GetAllFoldersByUserId(InnerUser.Id);

            if (foldersList == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<FolderReadDto>>(foldersList));
        }

        [HttpGet("{id}", Name = "GetFolderById")]
        public ActionResult GetFolderById(int id)
        {
            Folder folderItem = _repository.GetUserFolderById(InnerUser.Id, id);

            if (folderItem == null)
            {
                return NoContent();
            }

            var folderListModel =_mapper.Map<FolderReadDto>(folderItem);
            return Ok(folderListModel);
        }


        [HttpPost]
        public ActionResult<FolderReadDto> CreateFolder(FolderCreateDto createDto)
        {
            Folder folderItem = _mapper.Map<Folder>(createDto);
            folderItem.UserId = InnerUser.Id;

            _repository.CreateFolder(folderItem);
            _repository.SaveChanges();

            var folderDto = _mapper.Map<FolderReadDto>(folderItem);

            return CreatedAtRoute("GetFolderById", new { Id = folderDto.Id }, folderDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFolder(int id, FolderUpdateDto updateDto)
        {
            Folder folderItem = _repository.GetUserFolderById(InnerUser.Id, id);

            if (folderItem == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, folderItem);

            _repository.UpdateFolder(folderItem);
            _repository.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PartialFolderUpdate(int id, JsonPatchDocument<FolderUpdateDto> patchNote)
        {
            Folder folderItem = _repository.GetUserFolderById(InnerUser.Id, id);

            if (folderItem == null)
            {
                return NotFound();
            }

            var folderUpdatePatch = _mapper.Map<FolderUpdateDto>(folderItem);
            patchNote.ApplyTo(folderUpdatePatch, ModelState);

            if (!TryValidateModel(folderUpdatePatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(folderUpdatePatch, folderItem);

            _repository.UpdateFolder(folderItem);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFolder(int id)
        {
            Folder folderItem = _repository.GetUserFolderById(InnerUser.Id, id);

            if (folderItem == null)
            {
                return NotFound();
            }

            _repository.DeleteFolder(folderItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}