using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Controllers
{
    [Route("api/folders")]
    [ApiController]
    public class FoldersController : ControllerBase
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
            var foldersList = _repository.GetAllFolders();

            if (foldersList == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<FolderReadDto>>(foldersList));
        }

        [HttpGet("{id}", Name = "GetFolderById")]
        public ActionResult GetFolderById(int id)
        {
            var folderItem = _repository.GetFolderById(id);

            if (folderItem == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<FolderReadDto>(folderItem));
        }

        
        [HttpPost]
        public ActionResult<FolderReadDto> CreateFolder(FolderCreateDto createDto)
        {
            var folder = _mapper.Map<Folder>(createDto);
            folder.CreatedAt = DateTime.Now;

            _repository.CreateFolder(folder);
            _repository.SaveChanges();

            var folderDto = _mapper.Map<FolderReadDto>(folder);

            return CreatedAtRoute("GetFolderById", new { Id = folderDto.Id }, folderDto);
        }

    }
}