using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanySize { get; set; }

        public string CompanyUrl { get; set; }

        public string ContactNotes { get; set; }

        public bool HasMentor { get; set; }

        public bool HasProfDev { get; set; }
    }
}