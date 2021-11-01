using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}