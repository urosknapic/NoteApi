using System.ComponentModel.DataAnnotations;

namespace NoteApi.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}