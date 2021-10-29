using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
    }
}