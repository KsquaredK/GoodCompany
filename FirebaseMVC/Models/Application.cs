using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoodCompanyMVC.Models
{
    public class Application
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int UserProfileId { get; set; }

        public UserProfile UserProfile { get; set; }

        public int PositionLevelId { get; set; }

        public Positionlevel PositionLevel { get; set; }

        public List<Skill> Skills { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Date Listed")]
        [DataType(DataType.Date)]
        public DateTime DateListed { get; set; }

        [DisplayName("Date Applied")]
        [DataType(DataType.Date)]
        public DateTime? DateApplied { get; set; }

        [Required]
        public string NextAction { get; set; }

        [Required]
        [DisplayName("Next Action Due")]
        [DataType(DataType.Date)]
        public DateTime NextActionDue { get; set; }

        public int? SalaryRangeLow { get; set; }

        public int? SalaryRangeHigh { get; set; }

        public bool? FullBenefits { get; set; }
    }
}
 