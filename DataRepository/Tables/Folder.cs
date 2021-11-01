using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApi.Data.Tables
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}