using System.Collections.Generic;

namespace GoodCompanyMVC.Models.ViewModels
{
    public class ApplicationCreateViewModel
    {
        public Application Application { get; set; }

        public List<Company> CompanyOptions { get; set; }

        public List<Positionlevel> PositionLevelOptions { get; set; }

        public List<ApplicationNote> ApplicationNotes { get; set; }

        public List<Skill> Skills { get; set; }

    }
}