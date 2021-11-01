using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanySize { get; set; }

        [DisplayName("Company Site")]
        public string CompanyUrl { get; set; }

        public bool HasMentor { get; set; }

        public bool HasProfDev { get; set; }

        public UserProfile userProfile { get; set; }

        public int UserProfileId { get; set; }
    }
}