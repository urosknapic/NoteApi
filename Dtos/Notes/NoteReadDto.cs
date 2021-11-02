using System;

namespace NoteApi.Dtos
{
    public class NoteReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public bool IsListNote { get; set; }
    }
}