using System;

namespace NoteApi.Data.Tables
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}