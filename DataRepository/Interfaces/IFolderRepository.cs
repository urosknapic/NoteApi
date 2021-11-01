using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IFolderRepository : IBaseRepository
    {
        IEnumerable<Folder> GetAllFolders();
        Folder GetFolderById(int id);
        void CreteFolder(Folder folder);
        void UpdateFolder(Folder folder);
        void DeleteFolder(Folder folder);
    }
}