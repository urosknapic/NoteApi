using Microsoft.EntityFrameworkCore;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class FolderDbContext : DbContext
    {
        public FolderDbContext(DbContextOptions<FolderDbContext> options) : base(options) { }

        public DbSet<Folder> Folder { get; set; }
    }
}