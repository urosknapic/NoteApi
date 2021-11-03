using AutoMapper;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Profilers
{
    public class UserProfilerMapper : Profile
    {
        public UserProfilerMapper()
        {
            CreateMap<User, UserAuthenticateReadDto>();
        }
    }
}