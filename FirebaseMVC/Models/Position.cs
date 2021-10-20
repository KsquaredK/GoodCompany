using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class Position
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ComanyId { get; set; }

        public DateTime DateListed { get; set; }

        public string Notes { get; set; }

        public int SalaryRangeBottom { get; set; }

        public int SalaryRangeTop { get; set; }

        public bool FullBenefits { get; set; }
    }
}