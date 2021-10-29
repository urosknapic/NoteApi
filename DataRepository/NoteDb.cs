using Microsoft.EntityFrameworkCore;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class NoteDb : DbContext
    {
        public NoteDb(DbContextOptions<NoteDb> options) : base(options)
        {

        }

        public DbSet<NoteTables> Note { get; set; }
    }
}