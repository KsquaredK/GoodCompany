using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface ISkillRepository
    {
        void AddSkill(Skill skill);
        List<Skill> DeleteSkill(int id);
        List<Skill> GetAllSkills();
        List<Skill> GetAllSkillsByCurrentUser(int UserProfileId);
        Skill GetSkillsById(int id);
        void UpdateSkill(Skill skill);
    }
}