using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class FolderUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}