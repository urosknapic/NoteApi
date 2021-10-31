using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class NoteCreateDto
    {
        [Required]
        public string Title { get; set; }
    }
}