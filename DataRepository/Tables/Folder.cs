using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; } // FK user

        public IEnumerable<Note> Notes { get; set; }
    }
}