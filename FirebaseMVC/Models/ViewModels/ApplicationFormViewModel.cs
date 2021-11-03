using System.Collections.Generic;

namespace GoodCompanyMVC.Models.ViewModels
{
    public class ApplicationFormViewModel
    {
        public Application Application { get; set; }

        public List<Company> Company { get; set; }

        public List<Company> CompanyOptions { get; set; }

        public List<PositionLevel> PositionLevel { get; set; }

        public List<PositionLevel> PositionLevelOptions { get; set; }

        public List<ApplicationNote> ApplicationNotes { get; set; }

        public List<Skill> Skills { get; set; }

    }
}