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
            SeedTypeData(modelBuilder);
            SeedNoteData(modelBuilder);
            SeedContentNoteData(modelBuilder);
        }

        private void SeedContentNoteData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentNote>().HasData(new ContentNote(){
                Id = 1,
                NoteId = 5,
                Content = "Fix lights"
            });
            modelBuilder.Entity<ContentNote>().HasData(new ContentNote(){
                Id = 2,
                NoteId = 5,
                Content = "Paint walls"
            });
            modelBuilder.Entity<ContentNote>().HasData(new ContentNote(){
                Id = 3,
                NoteId = 7,
                Content = "This is so sicret that I had to write it down"
            });
        }

        private void SeedUserData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Name = "Janez Novak",
                UserName = "janezNovak",
                Password = "1234"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 2,
                Name = "Miha Nagode",
                UserName = "mihaNagode",
                Password = "4321"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 3,
                Name = "Anja Hudovernik",
                UserName = "anjaHudovernik",
                Password = "9999"
            });
        }

        private void SeedUsersFolders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>().HasData(new Folder()
            {
                Id = 1,
                Name = "HomeDirectory",
                UserId = 1
            });
            modelBuilder.Entity<Folder>().HasData(new Folder()
            {
                Id = 2,
                Name = "Dokumenti",
                UserId = 1
            });
            modelBuilder.Entity<Folder>().HasData(new Folder()
            {
                Id = 3,
                Name = "SomeRandomFolder",
                UserId = 1
            });

            modelBuilder.Entity<Folder>().HasData(new Folder()
            {
                Id = 4,
                Name = "ToJemihovFolder",
                UserId = 2
            });
        }

        private void SeedTypeData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>().HasData(new Type()
            {
                Id = 1,
                Name = "private"
            });
            modelBuilder.Entity<Type>().HasData(new Type()
            {
                Id = 2,
                Name = "public"
            });
        }

        private void SeedNoteData(ModelBuilder modelBuilder)
        {
            // janez notes
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 1,
                Name = "FirstNote.txt",
                Title = "Start of first note",
                FolderId = 2,
                TypeId = 1,
                UserId = 1,
                IsListNote = false
            });
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 2,
                Name = "Holidays.txt",
                Title = "Christmas plans:",
                FolderId = 2,
                TypeId = 2,
                UserId = 1,
                IsListNote = true
            });
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 3,
                Name = "PetTodoList.txt",
                Title = "What to do to get a new pet:",
                FolderId = 2,
                TypeId = 1,
                UserId = 1,
                IsListNote = true
            });
            // miha notes
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 4,
                Name = "Miha Europa CV",
                Title = "Profesional painter",
                FolderId = 4,
                TypeId = 2,
                UserId = 2,
                IsListNote = false
            });
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 5,
                Name = "Home Renovation TODO:",
                Title = "What to do to get a new pet:",
                FolderId = 4,
                TypeId = 1,
                UserId = 2,
                IsListNote = true
            });
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 6,
                Name = "Note 1",
                Title = "Some special note",
                FolderId = 4,
                TypeId = 2,
                UserId = 2,
                IsListNote = false
            });
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 7,
                Name = "Note 2",
                Title = "And a sicret note to someone",
                FolderId = 4,
                TypeId = 2,
                UserId = 2,
                IsListNote = false
            });
            modelBuilder.Entity<Note>().HasData(new Note()
            {
                Id = 8,
                Name = "Note 3",
                Title = "Motorbike parts",
                FolderId = 4,
                TypeId = 2,
                UserId = 2,
                IsListNote = false
            });
        }
    }
}