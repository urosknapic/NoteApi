using AutoMapper;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Profilers
{
    public class ContentNoteProfilerMapper : Profile
    {
        public ContentNoteProfilerMapper()
        {
            CreateMap<ContentNote, ContentNoteReadDto>();
            CreateMap<ContentNoteCreateDto, ContentNote>();
            CreateMap<ContentNoteUpdateDto, ContentNote>();
            CreateMap<ContentNote, ContentNoteUpdateDto>();
        }
    }
}