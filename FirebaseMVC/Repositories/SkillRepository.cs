using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;


namespace GoodCompanyMVC.Repositories
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(IConfiguration config) : base(config) { }

        public List<Skill> GetSkills()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name FROM Skill";

                    var reader = cmd.ExecuteReader();

                    List<Skill> skills = new List<Skill>();

                    while (reader.Read())
                    {
                        Skill skill = new Skill()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name")
                        };
                        skills.Add(skill);
                    }

                    reader.Close();

                    return skills;
                }

            }
        }

        public List<Skill> GetSkillsByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetSkillsByApplication(int applicationId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.[Name]
                                        FROM Skill s
                                        JOIN ApplicationSkill aps ON s.Id = aps.SkillId
                                        JOIN Application a ON a.Id = aps.ApplicationId
                                        WHERE a.Id = @id";
                    cmd.Parameters.AddWithValue("@id", applicationId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Skill> skills = new List<Skill>();
                        while (reader.Read())
                        {
                            Skill skill = new Skill()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name")
                            };
                            skills.Add(skill);
                        }
                        return skills;
                    }
                }
            }
        }

        public void AddSkill(Skill skill)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Skill (Name)
                        OUTPUT INSERTED.ID
                        VALUES (@name)";
                    cmd.Parameters.AddWithValue("@name", skill.Name);
                    int id = (int)cmd.ExecuteScalar();
                    skill.Id = id;
                }
            }
        }


        public void UpdateSkill(Skill skill)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Skill
                        SET Name = @name
                        Where Id = @id";

                    cmd.Parameters.AddWithValue("@name", skill.Name);
                    cmd.Parameters.AddWithValue("@id", skill.Id);

                    cmd.ExecuteScalar();
                }
            }
        }

        public Skill GetSkillById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Name, Id
                        FROM Skill
                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();

                    Skill skill = null;

                    if (reader.Read())
                    {
                        skill = new Skill()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name")
                        };
                    }
                    reader.Close();
                    return skill;
                }
            }
        }

        public void DeleteSkill(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM SKill
                            WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

