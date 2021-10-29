using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class CompanyNote
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public Company company { get; set; }

        public string Note { get; set; }
    }
}
