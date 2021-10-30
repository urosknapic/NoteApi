using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class BodyNote
    {
        [Key]
        public int Id { get; set; }
    }
}