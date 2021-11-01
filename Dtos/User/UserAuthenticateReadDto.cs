using System.ComponentModel.DataAnnotations;

namespace NoteApi.Dtos
{
    public class UserAuthenticateReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}