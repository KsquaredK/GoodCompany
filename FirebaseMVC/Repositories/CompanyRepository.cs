using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using Microsoft.Data.SqlClient;

namespace GoodCompanyMVC.Repositories
{
    public class CompanyRepository : BaseRepository
    {
        public CompanyRepository(IConfiguration config) : base(config) { }
        
        public List<Company> GetAllCompanies()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, [Name], CompanySize, CompanyNotes, HasMentor,  HasProfDev, CompanyUrl, ContactNotes
                                        FROM Company
                                        ORDER BY Name ASC";

                    var reader = cmd.ExecuteReader();
                    var companies = new List<Company>();

                    while (reader.Read())
                    {
                        companies.Add(NewCompanyFromReader(reader));
                    }

                    reader.Close();
                    return companies;
                }
            }              
                    
        }

        public List<Company> GetAllCompaniesByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
            //using (var cann = Connection)
            //{
            //    Connection.Open();
            //    using (var cmd = Connection.CreateCommand())
            //    {
            //        cmd.CommandText
            //    }
            //}
        }

        public void AddCompany(Company company)
        {
            throw new NotImplementedException();
        }   

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Company> DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        private Company NewCompanyFromReader(SqlDataReader reader)
        {
                return new Company()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name"),
                    CompanySize = DbUtils.GetString(reader, "CompanySize"),
                    CompanyNotes = DbUtils.GetString(reader, "Notes"),
                    HasMentor = DbUtils.GetBoolean(reader, "HasMentor"),
                    HasProfDev = DbUtils.GetBoolean(reader, "HasProfDev"),
                    CompanyUrl = DbUtils.GetString(reader, "CompanyUrl"),
                    ContactNotes = DbUtils.GetString(reader, "ContactNotes")

                };
        }

    }
}
