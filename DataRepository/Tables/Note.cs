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

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [ForeignKey("FolderId")]
        public int FolderId { get; set; }

        [ForeignKey("TypeId")]
        public int TypeId { get; set; }
        public IEnumerable<ContentNote> Content { get; set; }
        public Type Type { get; set; }
    }
}