using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface ISkillRepository
    {
        void AddSkill(Skill skill);

        void DeleteSkill(int id);

        List<Skill> GetSkills();

        List<Skill> GetSkillsByCurrentUser(int UserProfileId);

        List<Skill> GetSkillsByApplication(int applicationId);

        Skill GetSkillById(int id);

        void UpdateSkill(Skill skill);
    }
}