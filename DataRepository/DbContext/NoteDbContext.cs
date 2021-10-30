using Microsoft.EntityFrameworkCore;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) { }

        public DbSet<Note> Note { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>(e => e.Property(o => o.Title).HasColumnType("varchar(100)"));
        }
    }
}