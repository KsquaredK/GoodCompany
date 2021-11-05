using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;

namespace GoodCompanyMVC.Repositories
{
    public class PositionLevelRepository : BaseRepository, IPositionLevelRepository
    {
        public PositionLevelRepository(IConfiguration config) : base(config) { }
        public List<PositionLevel> GetPositionLevels()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Level FROM PositionLevel";

                    var reader = cmd.ExecuteReader();

                    List<PositionLevel> positionLevels = new List<PositionLevel>();

                    while (reader.Read())
                    {
                        PositionLevel positionLevel = new PositionLevel()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Level = DbUtils.GetString(reader, "Level")
                        };
                        positionLevels.Add(positionLevel);
                    }

                    reader.Close();

                    return positionLevels;
                }

            }


        }

        public void GetPositionLevelsByCurrentUser(int userProfileId)
        {
            throw new NotImplementedException();
        }


        public PositionLevel GetPositionLevelByApplication(int applicationId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      SELECT  p.Id AS Id, p.Level,
                              a.Id AS applicationId
                      FROM PositionLevel p
                      LEFT JOIN Application a ON a.PositionLevelId = p.Id
                      WHERE a.Id = @id";

                    cmd.Parameters.AddWithValue("@id", applicationId);


                    PositionLevel positionLevel = null;
                    using var reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            if (positionLevel == null)
                            {
                                //convert results of sql query to c# obj
                                positionLevel = new PositionLevel
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    Level = DbUtils.GetString(reader, "Level")
                                };
                            }

                        }
                        return positionLevel;
                    }
                }

            }
        }

        public void GetPositionLevelById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPositionLevel(PositionLevel positionLevel)
        {
            throw new NotImplementedException();
        }
        public void UpdatePositionLevel(PositionLevel positionLevel)
        {
            throw new NotImplementedException();
        }

        public void DeletePositionLevel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
