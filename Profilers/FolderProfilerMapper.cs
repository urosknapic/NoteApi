using AutoMapper;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Profilers
{
    public class FolderProfilerMapper : Profile
    {
        public FolderProfilerMapper()
        {
            CreateMap<Folder, FolderReadDto>();
            CreateMap<FolderCreateDto, Folder>();
            /* 
            CreateMap<NoteUpdateDto, Note>();
            CreateMap<Note, NoteUpdateDto>();
             */
        }
    }
}