using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
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

        public List<Application> GetApplications()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                {
                    cmd.CommandText = @"SELECT Id, PositionId, UserProfileId AS UserId, 
                                        DateApplied, NextAction, NextActionDue, 
                                        RecommenderNotes
                                        FROM Application
                                        ORDER BY DateApplied ASC";

                    var reader = cmd.ExecuteReader();
                    var applications = new List<Application>();

                    while (reader.Read())
                    {
                        Application application = new Application()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            PositionId = DbUtils.GetInt(reader, "PositionId"),
                            UserProfileId = DbUtils.GetInt(reader, "UserId"),
                            DateApplied = DbUtils.GetDateTime(reader, "DateApplied"),
                            NextAction = DbUtils.GetString(reader, "NextAction"),
                            NextActionDue = DbUtils.GetDateTime(reader, "NextActionDue"),
                            RecommenderNotes = DbUtils.GetString(reader, "RecommenderNotes")
                        };
                        applications.Add(application);
                        return applications;
                    }
                    return applications;
                }
            }
        }

        public List<Application> GetApplicationsByCurrentUser(int UserProfileId)
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

        public void DeleteApplication(int id)
        {
            throw new NotImplementedException();
        }

        private Application NewApplicationFromReader(SqlDataReader reader)
        {
            throw new NotImplementedException();

        }
    }
}