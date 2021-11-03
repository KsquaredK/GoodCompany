using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;

namespace GoodCompanyMVC.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {

        public CompanyRepository(IConfiguration config) : base(config) { }

        public List<Company> GetCompanies()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, CompanySize, HasMentor, HasProfDev, CompanyUrl
                                        FROM Company
                                        ORDER BY Name ASC";


                    var reader = cmd.ExecuteReader();
                    var companies = new List<Company>();

                    while (reader.Read())
                    {
                        Company company = new Company()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            CompanySize = DbUtils.GetString(reader, "CompanySize"),
                            CompanyUrl = DbUtils.GetString(reader, "CompanyUrl"),
                            HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                            HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev")
                        };
                    companies.Add(company);
                    }

                    reader.Close();
                    return companies;
                }
            }

        }
        
        public List<Company> GetCompaniesByCurrentUser(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                {
                    cmd.CommandText = @"SELECT c.Id, c.Name AS Company, c.CompanySize, c.CompanyUrl AS Website, c.HasMentor, c.HasProfDev, 
                                               u.Id
                                        FROM Company c
                                        LEFT JOIN Application a ON c.Id = a.CompanyId
                                        LEFT JOIN UserProfile u ON u.Id = a.UserProfileId
                                        WHERE a.UserProfileId = @userId";

                    cmd.Parameters.AddWithValue("@userId", userId);

                    var reader = cmd.ExecuteReader();
                    var companies = new List<Company>();

                    while (reader.Read())
                    {
                        Company company = new Company()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Company"),
                            CompanySize = DbUtils.GetString(reader, "CompanySize"),
                            CompanyUrl = DbUtils.GetString(reader, "Website"),
                            HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                            HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev")
                        };
                        companies.Add(company);
                        return companies;
                    }

                    reader.Close();
                    return companies;
                }
            }

        }

        public Company GetCompanyById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      SELECT  c.Id, c.Name, c.CompanySize, c.CompanyUrl AS Website, 
                              c.HasMentor, c.HasProfDev,
                              u.Id AS UserId
                      FROM Company c
                      LEFT JOIN Application a ON a.CompanyId = c.Id
                      LEFT JOIN UserProfile u ON u.Id = a.UserProfileId
                      WHERE c.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);


                    Company company = null;
                    using var reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            if (company == null)
                            {
                                //convert results of sql query to c# obj
                                company = new Company
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Name = DbUtils.GetString(reader, "Name"),
                                    CompanySize = DbUtils.GetString(reader, "CompanySize"),
                                    CompanyUrl = DbUtils.GetString(reader, "Website"),
                                    HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                                    HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev")
                                };

                            }
                        }
                        return company;
                    }
                }
            }

        }

            public void AddCompany(Company company)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                    INSERT INTO Company (Name, CompanySize, CompanyUrl, HasMentor, HasProfDev)
                    OUTPUT INSERTED.ID
                    VALUES (@Name, @CompanySize, @CompanyUrl, @HasMentor, @HasProfDev);
                    ";

                        cmd.Parameters.AddWithValue("@Name", company.Name);
                        cmd.Parameters.AddWithValue("@CompanySize", company.CompanySize);
                        cmd.Parameters.AddWithValue("@CompanyUrl", company.CompanyUrl);
                        cmd.Parameters.AddWithValue("@HasMentor", company.HasMentor);
                        cmd.Parameters.AddWithValue("@HasProfDev", company.HasProfDev);

                        company.Id = (int)cmd.ExecuteScalar();
                    }
                }
            }

            public void UpdateCompany(Company company)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        UPDATE Company
                        SET
                            Name = @name,
                            CompanySize = @companySize,
                            CompanyUrl = @companyUrl,
                            HasMentor = @hasMentor,
                            HasProfDev = @hasProfDev
                            WHERE Id = @id";

                        cmd.Parameters.AddWithValue("@Id", company.Id);
                        cmd.Parameters.AddWithValue("@Name", company.Name);
                        cmd.Parameters.AddWithValue("@CompanySize", company.CompanySize);
                        cmd.Parameters.AddWithValue("@CompanyUrl", company.CompanyUrl);

                    if (company.HasMentor != null)
                    {
                        cmd.Parameters.AddWithValue("@HasMentor", company.HasMentor);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HasMentor", DBNull.Value);

                    }

                    if (company.HasProfDev != null)
                    {
                        cmd.Parameters.AddWithValue("@HasProfDev", company.HasProfDev);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HasProfDev", DBNull.Value);

                    }
                    cmd.ExecuteNonQuery();

                    }
                }
            }

            public void DeleteCompany(int id)
            {
                using (var conn = Connection)
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                            DELETE FROM Company
                            WHERE Id = @id
                        ";

                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
    }
}
