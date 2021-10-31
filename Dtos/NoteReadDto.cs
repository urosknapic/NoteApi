using System;
using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class NoteReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}