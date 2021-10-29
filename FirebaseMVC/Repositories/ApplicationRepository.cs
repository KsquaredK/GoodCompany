using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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
                    cmd.CommandText = @"SELECT a.Id, a.CompanyId, a.Title, a.DateListed, a.DateApplied,
                                                        a.NextAction, a.NextActionDue, a.SalaryRangeLow, a.SalaryRangeHigh,
                                                        a.FullBenefits,
                                                        c.Name
                                                        FROM Application a 
                                                        LEFT JOIN Company c ON c.Id = a.CompanyId
                                                        ORDER BY a.NextActionDue DESC";

                    var reader = cmd.ExecuteReader();
                    var applications = new List<Application>();

                    while (reader.Read())
                    {
                        Application application = new Application()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            DateApplied = DbUtils.GetDateTime(reader, "DateApplied"),
                            NextAction = DbUtils.GetString(reader, "NextAction"),
                            NextActionDue = DbUtils.GetDateTime(reader, "NextActionDue"),
                            CompanyId = DbUtils.GetInt(reader, "CompanyId"),
                            Company = new Company()
                            {
                                Name = DbUtils.GetString(reader, "Name")
                            }
                        };
                        applications.Add(application);
                    }
                    return applications;
                }
            }
        }
        public List<Application> GetAllApplicationsByCurrentUser(int UserProfileId)
        {

            using (var conn = Connection)
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                {
                    cmd.CommandText = @"SELECT a.Id, a.CompanyId, a.Title, a.DateListed, a.DateApplied,
                                                        a.NextAction, a.NextActionDue, a.SalaryRangeLow, a.SalaryRangeHigh,
                                                        a.FullBenefits,
                                                        c.Name,
                                                        u.Name AS UserName, u.Id AS UserId
                                                        FROM Application a 
                                                        LEFT JOIN Company c ON c.Id = a.CompanyId
                                                        LEFT JOIN UserProfile u ON u.Id = a.UserProfileId
                                                        WHERE u.Id = a.UserProfileId
                                                        ORDER BY a.NextActionDue DESC";

                    var reader = cmd.ExecuteReader();
                    var applications = new List<Application>();

                    while (reader.Read())
                    {
                        Application application = new Application()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Title = DbUtils.GetString(reader, "Title"),
                            DateApplied = DbUtils.GetDateTime(reader, "DateApplied"),
                            DateListed = DbUtils.GetDateTime(reader, "DateListed"),
                            NextAction = DbUtils.GetString(reader, "NextAction"),
                            NextActionDue = DbUtils.GetDateTime(reader, "NextActionDue"),
                            SalaryRangeLow = DbUtils.GetInt(reader, "SalaryRangeLow"),
                            SalaryRangeHigh = DbUtils.GetInt(reader, "SalaryRangeHigh"),
                            FullBenefits = DbUtils.GetBoolean(reader, "FullBenefits"),
                            CompanyId = DbUtils.GetInt(reader, "CompanyId"),
                            Company = new Company()
                            {
                                Name = DbUtils.GetString(reader, "Name")
                            },
                            UserProfileId = DbUtils.GetInt(reader, "UserId"),
                            UserProfile = new UserProfile()
                            {
                                Name = DbUtils.GetString(reader, "Name")
                            },
                        };
                        applications.Add(application);
                    }
                    return applications;
                }
            }
        }

        public void AddAplication(Application application)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public Skill GetApplicationsById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> DeleteApplication(int id)
        {
            throw new NotImplementedException();
        }
    }
}




