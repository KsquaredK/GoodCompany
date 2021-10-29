using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IApplicationRepository
    {
        void AddAplication(Application application);
        List<Skill> DeleteApplication(int id);
        List<Application> GetAllApplicationsByCurrentUser(int UserProfileId);
        List<Application> GetApplications();
        Skill GetApplicationsById(int id);
        void UpdateApplication(Application application);
    }
}