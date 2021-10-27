using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using Microsoft.Data.SqlClient;
using System;

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
                    cmd.CommandText = @"SELECT Id, Name, CompanySize, HasMentor, HasProfDev, CompanyUrl, ContactNotes
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
                            HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                            HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev"),
                            CompanyUrl = DbUtils.GetString(reader, "CompanyUrl"),
                            ContactNotes = DbUtils.GetString(reader, "ContactNotes"),
                        };
                    companies.Add(company);
                    }

                    reader.Close();
                    return companies;
                }
            }

        }
        
        public List<Company> GetCompaniesByUser(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.Name AS Company, c.CompanySize, c.CompanyUrl AS Website, c.HasMentor, c.HasProfDev, c.ContactNotes,
                                               p.CompanyId, 
                                               p.Title AS Position, 
                                               u.Id
                                        FROM Company c
                                        LEFT JOIN Position p ON c.Id = p.CompanyId
                                        LEFT JOIN Application a ON a.PositionId = p.Id
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
                            HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                            HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev"),
                            CompanyUrl = DbUtils.GetString(reader, "Website"),
                            ContactNotes = DbUtils.GetString(reader, "ContactNotes"),
                        };
                        companies.Add(company);
                        return companies;
                    }

                    reader.Close();
                    return companies;
                }
            }

        }

        public Company GetCompanyById(int id, int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      SELECT  c.Id, c.Name, c.CompanyUrl, c.ContactNotes, c.HasMentor, c.HasProfDev,
                              p.Title,
                              u.Id AS UserId
                      FROM Company c
                      LEFT JOIN Position p ON c.Id = p.CompanyId
                      LEFT JOIN Application a ON a.PositionId = p.Id
                      LEFT JOIN UserProfile u ON u.Id = a.UserProfileId
                      WHERE c.Id = @id AND u.id = @userId
                      ORDER BY c.Name ASC";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@userId", userId);


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
                                    HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                                    HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev"),
                                    CompanyUrl = DbUtils.GetString(reader, "CompanyUrl"),
                                    ContactNotes = DbUtils.GetString(reader, "ContactNotes")
                                    //add position available as stretch goal
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
                    INSERT INTO Company (Name, CompanySize, CompanyUrl, ContactNotes, HasMentor, HasProfDev)
                    OUTPUT INSERTED.ID
                    VALUES (@Name, @CompanySize, @CompanyUrl, @ContactNotes, @HasMentor, @HasProfDev);
                    ";

                        cmd.Parameters.AddWithValue("@Name", company.Name);
                        cmd.Parameters.AddWithValue("@CompanySize", company.CompanySize);
                        cmd.Parameters.AddWithValue("@CompanyUrl", company.CompanyUrl);
                        cmd.Parameters.AddWithValue("@ContactNotes", company.ContactNotes);
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
                            ContactNotes  = @contactNotes,
                            HasMentor = @hasMentor,
                            HasProfDev = @hasProfDev
                            WHERE Id = @id";

                        cmd.Parameters.AddWithValue("@Id", company.Id);
                        cmd.Parameters.AddWithValue("@Name", company.Name);
                        cmd.Parameters.AddWithValue("@CompanySize", company.CompanySize);
                        cmd.Parameters.AddWithValue("@CompanyUrl", company.CompanyUrl);


                    if (company.ContactNotes != null)
                    {
                        cmd.Parameters.AddWithValue("@ContactNotes", company.ContactNotes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ContactNotes", DBNull.Value);
                    }

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
            //    private Company NewCompanyFromReader(SqlDataReader reader)
            //{
            //    Company company = new Company()
            //    {
            //        Name = DbUtils.GetString(reader, "Name"),
            //        HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
            //        HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev"),
            //        CompanyUrl = DbUtils.GetString(reader, "CompanyUrl"),
            //        ContactNotes = DbUtils.GetString(reader, "ContactNotes"),
            //    };
            //    return company;
            //}
        
    }
}
