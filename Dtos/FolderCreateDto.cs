using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class FolderCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}