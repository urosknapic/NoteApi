using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IUserRepository : IBaseRepository
    {
        User GetUserById(int id);
    }
}