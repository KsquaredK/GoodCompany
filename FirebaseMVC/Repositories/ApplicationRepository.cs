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
                            DateApplied = DbUtils.GetNullableDateTime(reader, "DateApplied"),
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
                        DateApplied = DbUtils.GetNullableDateTime(reader, "DateApplied"),
                        DateListed = DbUtils.GetDateTime(reader, "DateListed"),
                        NextAction = DbUtils.GetString(reader, "NextAction"),
                        NextActionDue = DbUtils.GetDateTime(reader, "NextActionDue"),
                        SalaryRangeLow = DbUtils.GetNullableInt(reader, "SalaryRangeLow"),
                        SalaryRangeHigh = DbUtils.GetNullableInt(reader, "SalaryRangeHigh"),
                        FullBenefits = DbUtils.GetNullableBool(reader, "FullBenefits"),
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
                                            a.PositionLevelId,
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
                                    DateApplied = DbUtils.GetNullableDateTime(reader, "DateApplied"),
                                    PositionLevelId = DbUtils.GetInt(reader, "PositionLevelId"),
                                    DateListed = DbUtils.GetDateTime(reader, "DateListed"),
                                    NextAction = DbUtils.GetString(reader, "NextAction"),
                                    NextActionDue = DbUtils.GetDateTime(reader, "NextActionDue"),
                                    SalaryRangeLow = DbUtils.GetNullableInt(reader, "SalaryRangeLow"),
                                    SalaryRangeHigh = DbUtils.GetNullableInt(reader, "SalaryRangeHigh"),
                                    FullBenefits = DbUtils.GetNullableBool(reader, "FullBenefits"),
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
                                    PositionLevelId, Title, DateListed, DateApplied,
                                    NextAction, NextActionDue, SalaryRangeLow, 
                                    SalaryRangeHigh, FullBenefits)
                        OUTPUT INSERTED.ID
                        VALUES (@CompanyId, @UserProfileId, @PositionLevelId, @Title,
                                @DateListed, @DateApplied, @NextAction, @NextActionDue,
                                @SalaryRangeLow, @SalaryRangeHigh, @FullBenefits); ";

                    cmd.Parameters.AddWithValue("@CompanyId", application.CompanyId);
                    cmd.Parameters.AddWithValue("@UserProfileId", application.UserProfileId);
                    cmd.Parameters.AddWithValue("@PositionLevelId", application.PositionLevelId);
                    cmd.Parameters.AddWithValue("@Title", application.Title);
                    cmd.Parameters.AddWithValue("@DateListed", application.DateListed);
                    cmd.Parameters.AddWithValue("@DateApplied", DbUtils.ValueOrDBNull(application.DateApplied));
                    cmd.Parameters.AddWithValue("@NextAction", application.NextAction);
                    cmd.Parameters.AddWithValue("@NextActionDue", application.NextActionDue);
                    cmd.Parameters.AddWithValue("@SalaryRangeLow", DbUtils.ValueOrDBNull(application.SalaryRangeLow));
                    cmd.Parameters.AddWithValue("@SalaryRangeHigh", DbUtils.ValueOrDBNull(application.SalaryRangeHigh));
                    cmd.Parameters.AddWithValue("@FullBenefits", DbUtils.ValueOrDBNull(application.FullBenefits));

                    application.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdateApplication(Application application)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Application
                        SET 
                            CompanyId = @CompanyId,
                            UserProfileId = @UserProfileId,
                            PositionLevelId = @PositionLevelId,
                            Title = @Title, 
                            DateListed = @DateListed,
                            DateApplied = @DateApplied,
                            NextAction = @NextAction,
                            NextActionDue = @NextActionDue,
                            SalaryRangeLow = @SalaryRangeLow,
                            SalaryRangeHigh = @SalaryRangeHigh,
                            FullBenefits = @FullBenefits
                        WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", application.Id);
                    cmd.Parameters.AddWithValue("@CompanyId", application.CompanyId);
                    cmd.Parameters.AddWithValue("@UserProfileId", application.UserProfileId);
                    cmd.Parameters.AddWithValue("@PositionLevelId", application.PositionLevelId);
                    cmd.Parameters.AddWithValue("@Title", application.Title);
                    cmd.Parameters.AddWithValue("@DateListed", application.DateListed);
                    cmd.Parameters.AddWithValue("@NextAction", application.NextAction);
                    cmd.Parameters.AddWithValue("@NextActionDue", application.NextActionDue);

                    if (application.DateApplied != null)
                    {
                        cmd.Parameters.AddWithValue("@DateApplied", application.DateApplied);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DateApplied", DBNull.Value);
                    }

                    if (application.SalaryRangeLow != null)
                    {
                        cmd.Parameters.AddWithValue("@SalaryRangeLow", application.SalaryRangeLow);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SalaryRangeLow", DBNull.Value);
                    }

                    if (application.SalaryRangeHigh != null)
                    {
                        cmd.Parameters.AddWithValue("@SalaryRangeHigh", application.SalaryRangeHigh);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SalaryRangeHigh", DBNull.Value);
                    }

                    if (application.FullBenefits != null)
                    {
                        cmd.Parameters.AddWithValue("@FullBenefits", application.FullBenefits);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FullBenefits", DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteApplication(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                {
                    cmd.CommandText = @"
                    DELETE FROM Application
                    WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}




