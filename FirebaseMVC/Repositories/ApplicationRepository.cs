using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

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
        public List<Application> GetApplicationsByCurrentUser(int UserId)
        {

            using var conn = Connection;
            
            conn.Open();
            using var cmd = conn.CreateCommand();
            {
                cmd.CommandText = @"SELECT a.Id, a.CompanyId, a.Title, a.DateListed, a.DateApplied,
                                        a.NextAction, a.NextActionDue, a.SalaryRangeLow, a.SalaryRangeHigh,
                                        a.FullBenefits,
                                        c.Name AS CompanyName,
                                        u.Name AS UserName, u.Id AS UserId
                                    FROM Application a 
                                    LEFT JOIN Company c ON c.Id = a.CompanyId
                                    LEFT JOIN UserProfile u ON u.Id = a.UserProfileId
                                    WHERE u.Id = @userId
                                    ORDER BY a.NextActionDue DESC";

                cmd.Parameters.AddWithValue("@userId", UserId);

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
                            Name = DbUtils.GetString(reader, "CompanyName")
                        },
                        UserProfileId = DbUtils.GetInt(reader, "UserId"),
                        UserProfile = new UserProfile()
                        {
                            Name = DbUtils.GetString(reader, "UserName")
                        },
                    };
                    applications.Add(application);
                    return applications;
                }
                return applications;
            }
        }



        public Application GetApplicationById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                {
                    cmd.CommandText = @"SELECT a.Id AS Id, a.CompanyId, a.Title, a.DateListed, a.DateApplied,
                                        a.NextAction, a.NextActionDue, a.SalaryRangeLow, a.SalaryRangeHigh,
                                        a.FullBenefits,
                                        c.Name AS CompanyName,
                                        u.Name AS UserName, u.Id AS UserId
                                    FROM Application a 
                                    LEFT JOIN Company c ON c.Id = a.CompanyId
                                    LEFT JOIN UserProfile u ON u.Id = a.UserProfileId
                                    WHERE a.Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", id);

                    Application application = null;
                    using var reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            if (application == null)
                            {
                                application = new Application
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
                                        Name = DbUtils.GetString(reader, "CompanyName")
                                    },
                                    UserProfileId = DbUtils.GetInt(reader, "UserId"),
                                    UserProfile = new UserProfile()
                                    {
                                        Name = DbUtils.GetString(reader, "UserName")
                                    },
                                };
                            }
                        }
                        return application;
                    }
                }
            }
        }

        public void AddApplication(Application application)
        {
            using (var conn = Connection)
                {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Application (CompanyId, UserProfileId,
                                    Title, DateListed, DateApplied, NextAction,
                                    NextActionDue, SalaryRangeLow, SalaryRangeHigh,
                                    FullBenefits)
                        OUTPUT INSERTED.ID
                        VALUES (@CompanyId, @UserProfileId, @Title,
                                @DateListed, @DateApplied, @NextAction, @NextActionDue,
                                @SalaryRangeLow, @SalaryRangeHigh, @FullBenefits); ";

                    cmd.Parameters.AddWithValue("@CompanyId", application.CompanyId);
                    cmd.Parameters.AddWithValue("@UserProfileId", application.UserProfileId);
                    cmd.Parameters.AddWithValue("@Title", application.Title);
                    cmd.Parameters.AddWithValue("@DateApplied", DbUtils.ValueOrDBNull(application.DateApplied));
                    cmd.Parameters.AddWithValue("@NextAction", application.NextAction);
                    cmd.Parameters.AddWithValue("@NextActionDue", application.NextActionDue);
                    cmd.Parameters.AddWithValue("@DateListed", application.DateListed);
                    cmd.Parameters.AddWithValue("@SalaryRangeLow", DbUtils.ValueOrDBNull(application.SalaryRangeLow));
                    cmd.Parameters.AddWithValue("@SalaryRangeHigh", DbUtils.ValueOrDBNull(application.SalaryRangeHigh));
                    cmd.Parameters.AddWithValue("@FullBenefits", DbUtils.ValueOrDBNull(application.FullBenefits));

                    application.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public void DeleteApplication(int id)
        {
            throw new NotImplementedException();
        }
    }
}




