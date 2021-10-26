using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IApplicationRepository
    {
        void AddApplication(Application application);
        List<Application> DeleteApplication(int id);
        List<Application> GetAllApplications();
        List<Application> GetAllApplicationsByCurrentUser(int UserProfileId);
        Application GetApplicationById(int id);
        void UpdateApplication(Application application);
    }
}