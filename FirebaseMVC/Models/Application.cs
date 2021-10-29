using System;

namespace GoodCompanyMVC.Models
{
    public class Application
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public Company company { get; set; }

        public int UserProfileId { get; set; }

        public UserProfile UserProfile { get; set; }

        public DateTime DateListed { get; set; }

        public DateTime DateApplied { get; set; }

        public string NextAction { get; set; }

        public DateTime NextActionDue { get; set; }

        public int SalaryRangeLow { get; set; }

        public int SalaryRangeHigh { get; set; }

        public bool FullBenefits { get; set; }
    }
}
 