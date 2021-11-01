using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        public IEnumerable<Folder> Folders { get; set; }
    }
}