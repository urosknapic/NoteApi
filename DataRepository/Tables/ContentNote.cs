using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class ContentNote
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int IdNote { get; set; } // FK note
    }
}