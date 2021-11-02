using System.Collections.Generic;

namespace NoteApi.Dtos
{
    public class FolderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<NoteReadDto> Notes { get; set; }
    }
}