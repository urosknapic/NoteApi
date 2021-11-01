using System.Linq;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class MYSQLUserRepository : IUserRepository
    {        
        private NoteDbContext _context;

        public MYSQLUserRepository(NoteDbContext noteContext)
        {
            _context = noteContext;
        }

        public User GetUserById(int id)
        {
            return _context.User.Where(user => user.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}