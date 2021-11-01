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
            /* CreateMap<NoteCreateDto, Note>();
            CreateMap<NoteUpdateDto, Note>();
            CreateMap<Note, NoteUpdateDto>();
             */
        }
    }
}