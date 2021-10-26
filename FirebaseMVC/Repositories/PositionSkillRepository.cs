using GoodCompanyMVC.Models;
using GoodCompanyMVC.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace GoodCompanyMVC.Repositories
{
    public class PositionSkillRepository : BaseRepository, IPositionSkillRepository
    {
        public PositionSkillRepository(IConfiguration config) : base(config) { }

        public List<PositionSkill> GetAllPositionSkills()
        {
            throw new NotImplementedException();
        }

        public List<PositionSkill> GetAllPositionSkillsByCurrentUser(int UserProfileId)
        {
            throw new NotImplementedException();
        }

        public void AddPositionSkill(PositionSkill positionSkill)
        {
            throw new NotImplementedException();
        }

        public void UpdatePositionSkill(PositionSkill positionSkill)
        {
            throw new NotImplementedException();
        }

        public PositionSkill GetPositionSkillById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PositionSkill> DeletePositionSkill(int id)
        {
            throw new NotImplementedException();
        }

        private PositionSkill NewPositionSkillFromReader(SqlDataReader reader)
        {
            throw new NotImplementedException();

        }
    }
}
