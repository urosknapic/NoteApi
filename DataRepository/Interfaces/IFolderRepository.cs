using System.Collections.Generic;
using NoteApi.Data.Tables;

namespace NoteApi.Data
{
    public interface IFolderRepository : IBaseRepository
    {
        IEnumerable<Folder> GetAllFolders();
        Folder GetFolderById(int id);
        void CreteFolder(Folder note);
        void UpdateFolder(Folder note);
        void DeleteFolder(Folder note);
    }
}