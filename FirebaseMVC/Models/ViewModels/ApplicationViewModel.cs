using System.Collections.Generic;


namespace GoodCompanyMVC.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }

        public Company Company { get; set; }

        public  int CompanyId { get; set; }

        public List<Position> Position { get; set; }

        public int PositionId { get; set; }

        public int PositionSkillId { get; set; }

        public List<Skill> Skill { get; set; }

        public int SkillId { get; set; }

        public List<UserProfile> UserProfile { get; set; }

        public int UserProfileId { get; set; }

    }
}
