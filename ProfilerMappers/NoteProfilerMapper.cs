using System.Collections.Generic;
using AutoMapper;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Profilers
{
    public class NoteProfilerMapper : Profile
    {
        public NoteProfilerMapper()
        {
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteCreateDto, Note>();
            CreateMap<NoteUpdateDto, Note>();
            CreateMap<Note, NoteUpdateDto>();
        }
    }
}