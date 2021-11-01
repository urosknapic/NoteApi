using Microsoft.EntityFrameworkCore;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) { }

        public DbSet<Note> Note { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<ContentNote> ContentNote { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>(e => e.Property(o => o.Title).HasColumnType("varchar(100)"));
        }

        
    }
}