using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
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

    }
}