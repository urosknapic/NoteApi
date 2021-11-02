using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApi.Data.Tables
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [ForeignKey("FolderId")]
        public int FolderId { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public IEnumerable<ContentNote> Content { get; set; }
        public Type Type { get; set; }

        public bool IsListNote { get; set; }
    }
}