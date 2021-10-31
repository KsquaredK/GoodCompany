using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IApplicationRepository
    {
        List<Application> GetApplications();

        List<Application> GetApplicationsByCurrentUser(int UserProfileId);

        Application GetApplicationById(int id);

        void AddApplication(Application application);


        void UpdateApplication(Application application);


        void DeleteApplication(int id);
    }
}