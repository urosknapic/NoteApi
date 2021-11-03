using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class UserAuthenticateDto 
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}