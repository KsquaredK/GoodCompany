using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IApplicationNoteRepository
    {
        void AddApplicationNote(ApplicationNote applicationNote);
        List<ApplicationNote> DeleteApplicationNote(int id);
        List<ApplicationNote> GetAllApplicationNotesByCurrentUser(int UserProfileId);
        List<ApplicationNote> GetApplicationNotes();
        ApplicationNote GetApplicationNotesById(int id);
        void UpdateApplicationNote(ApplicationNote applicationNote);
    }
}