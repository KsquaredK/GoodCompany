using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace GoodCompanyMVC.Repositories
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(IConfiguration config) : base(config) { }

        public List<Skill> GetAllSkills()
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAllSkillsByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
        }

        public void AddSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public void UpdateSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Skill GetSkillsById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> DeleteSkill(int id)
        {
            throw new NotImplementedException();
        }

        private Skill NewSkillFromReader(SqlDataReader reader)
        {
            throw new NotImplementedException();

        }
    }
}

