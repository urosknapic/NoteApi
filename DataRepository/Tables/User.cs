using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}