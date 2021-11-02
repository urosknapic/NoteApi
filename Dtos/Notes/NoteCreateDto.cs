using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class NoteCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int FolderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TypeId { get; set; }

    }
}