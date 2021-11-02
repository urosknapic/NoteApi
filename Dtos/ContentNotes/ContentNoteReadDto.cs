using System;

namespace NoteApi.Dtos
{
    public class ContentNoteReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int NoteId { get; set; }
    }
}