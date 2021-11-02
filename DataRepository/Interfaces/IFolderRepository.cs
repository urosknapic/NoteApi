using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IFolderRepository : IBaseRepository
    {
        IEnumerable<Folder> GetAllFoldersByUserId(int userId);
        Folder GetUserFolderById(int userId, int id);
        void CreateFolder(Folder folder);
        void UpdateFolder(Folder folder);
        void DeleteFolder(Folder folder);
    }
}