using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }
    }
}