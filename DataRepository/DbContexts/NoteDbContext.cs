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

            SeedUserData(modelBuilder);
            SeedUsersFolders(modelBuilder);

        }

        private void SeedUsersFolders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>().HasData(new Folder(){
                Id = 1,
                Name = "HomeDirectory",
                UserId = 1
            });
            modelBuilder.Entity<Folder>().HasData(new Folder(){
                Id = 2,
                Name = "Dokumenti",
                UserId = 1
            });
            modelBuilder.Entity<Folder>().HasData(new Folder(){
                Id = 3,
                Name = "SomeRandomFolder",
                UserId = 1
            });
        }

        private void SeedUserData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User(){
                Id = 1,
                Name = "Janez Novak",
                UserName = "janezNovak",
                Password = "1234"
            });
            modelBuilder.Entity<User>().HasData(new User(){
                Id = 2,
                Name = "Miha Nagode",
                UserName = "mihaNagode",
                Password = "4321"
            });
            modelBuilder.Entity<User>().HasData(new User(){
                Id = 3,
                Name = "Anja Hudovernik",
                UserName = "anjaHudovernik",
                Password = "9999"
            });
        }
    }
}