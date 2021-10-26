using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IPositionSkillRepository
    {
        void AddPositionSkill(PositionSkill positionSkill);
        List<PositionSkill> DeletePositionSkill(int id);
        List<PositionSkill> GetAllPositionSkills();
        List<PositionSkill> GetAllPositionSkillsByCurrentUser(int UserProfileId);
        PositionSkill GetPositionSkillById(int id);
        void UpdatePositionSkill(PositionSkill positionSkill);
    }
}