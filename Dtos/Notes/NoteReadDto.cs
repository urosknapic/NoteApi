using System.Collections.Generic;
using NoteApi.Data.Tables;

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
        public IEnumerable<ContentNoteReadDto> Content { get; set; }
        public Type Type { get; set; }
    }
}