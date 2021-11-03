using System.Collections.Generic;
using System.Linq;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public class MYSQLTypeRepository : ITypeRepository
    {
        private NoteDbContext _context;

        public MYSQLTypeRepository(NoteDbContext noteContext)
        {
            _context = noteContext;
        }

        public IEnumerable<Type> GetAllTypes()
        {
            return _context.Type.ToList();
        }

        public Type GetTypeById(int id)
        {
            return _context.Type.Where(type => type.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return false;
        }
    }
}