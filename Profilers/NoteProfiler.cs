using AutoMapper;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Profilers
{
    public class NoteProfiler : Profile
    {
        public NoteProfiler()
        {
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteCreateDto, Note>();
            CreateMap<NoteUpdateDto, Note>();
        }
    }
}