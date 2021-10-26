using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace GoodCompanyMVC.Repositories
{
    public class PositionRepository : BaseRepository, IPositionRepository
    {
        public PositionRepository(IConfiguration config) : base(config) { }

        public List<Position> GetPositions()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT p.Id, p.Title, p.DateListed,
                                        c.Name
                                        FROM Position p
                                        LEFT JOIN Company c ON p.CompanyId = c.Id
                                        ORDER BY DateListed DESC";

                    var reader = cmd.ExecuteReader();
                    List<Position> positions = new List<Position>();

                    while (reader.Read())
                    {
                        Position position = new Position()
                        {
                            Title = DbUtils.GetString(reader, "Title"),
                            DateListed = DbUtils.GetDateTime(reader, "Datelisted"),
                            Company = new Company()
                            {
                                Name = DbUtils.GetString(reader, "DateListed")
                            }
                        };
                        return positions;
                    }

                    reader.Close();
                    return positions;
                }
            }

        }


        public List<Position> GetAllPositionsByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
        }

        public void AddPosition(Position position)
        {
            throw new NotImplementedException();
        }

        public void UpdatePosition(Position position)
        {
            throw new NotImplementedException();
        }

        public Position GetPositionById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Position> DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        private Position NewPositionFromReader(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

    }
}