using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IApplicationRepository
    {
        List<Application> GetApplications();

        List<Application> GetApplicationsByCurrentUser(int UserProfileId);

        Skill GetApplicationsById(int id);

        void AddAplication(Application application);

        void UpdateApplication(Application application);

        List<Skill> DeleteApplication(int id);
    }
}