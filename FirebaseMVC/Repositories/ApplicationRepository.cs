using GoodCompanyMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Repositories
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        public ApplicationRepository(IConfiguration config) : base(config) { }

        public List<Application> GetAllApplications()
        {
            throw new NotImplementedException();
        }

        public List<Application> GetAllApplicationsByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
        }

        public void AddApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public Application GetApplicationById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Application> DeleteApplication(int id)
        {
            throw new NotImplementedException();
        }

        private Application NewApplicationFromReader(SqlDataReader reader)
        {
            throw new NotImplementedException();

        }
    }
}