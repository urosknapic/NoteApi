using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApi.Data.Tables
{
    public class ContentNote
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        [ForeignKey("NoteId")]
        public int NoteId { get; set; }
    }
}