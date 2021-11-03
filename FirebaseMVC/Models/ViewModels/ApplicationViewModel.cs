using System.Collections.Generic;


namespace GoodCompanyMVC.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }

        public List<Company> Companies { get; set; }

        public List<PositionLevel> PositionLevels { get; set; }

        public List<ApplicationNote>  ApplicationNotes { get; set; }

        public List<Skill> Skills { get; set; }

    }
}
