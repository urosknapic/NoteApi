using System;

namespace NoteApi.Dtos
{
    public class NoteReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool ActiveInDto { get; set; } // this not exists in DB
    }
}