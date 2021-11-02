using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface ITypeRepository : IBaseRepository
    {
        IEnumerable<Type> GetAllTypes();
        Type GetTypeById(int id);
    }
}