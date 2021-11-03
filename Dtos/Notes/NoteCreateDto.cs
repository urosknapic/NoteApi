using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class NoteCreateDto : NoteUpdateDto
    {
        [Required]
        public int UserId { get; set; }
    }
}