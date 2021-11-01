using System.ComponentModel.DataAnnotations;

namespace NoteApi.Data.Tables
{
    public class ContentNote
    {
        [Key]
        public int Id { get; set; }
    }
}