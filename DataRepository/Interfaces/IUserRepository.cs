using System.Collections.Generic;
using System.Threading.Tasks;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IUserRepository : IBaseRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAllUsers();
    }
}