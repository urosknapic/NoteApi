using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _context.User.SingleOrDefault(x => x.UserName == username && x.Password == password));
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await Task.Run(() => _context.User.ToList());
        }

        public bool SaveChanges()
        {
            return false;
        }
    }
}