using System;
using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Dtos
{
    public class FolderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}