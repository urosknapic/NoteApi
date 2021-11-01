using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IdFolder { get; set; } // FK folder
        public int IdType { get; set; } // FK type
        public IEnumerable<ContentNote> Content { get; set; }
    }
}