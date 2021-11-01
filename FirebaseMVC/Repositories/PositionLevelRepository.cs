using GoodCompanyMVC.Models.ViewModels;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace GoodCompanyMVC.Repositories
{
    public class PositionLevelRepository : BaseRepository, IPositionLevelRepository
    {
        public PositionLevelRepository(IConfiguration config) : base(config) { }
        public List<Positionlevel> GetPositionLevels()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Level FROM PositionLevel";

                    var reader = cmd.ExecuteReader();

                    List<Positionlevel> positionLevels = new List<Positionlevel>();

                    while (reader.Read())
                    {
                        Positionlevel positionLevel = new Positionlevel()
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
    }
}
