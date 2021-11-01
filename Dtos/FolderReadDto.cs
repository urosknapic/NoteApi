using System;

namespace NoteApi.Dtos
{
    public class FolderReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}