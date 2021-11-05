using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company size is required.")]
        [DisplayName("Company Size")]
        public string CompanySize { get; set; }

        [Required(ErrorMessage = "Company site is required.")]
        [DisplayName("Company Site")]
        public string CompanyUrl { get; set; }

        [DisplayName("Has Mentoring")]
        public bool HasMentor { get; set; }

        [DisplayName("Has Professional Development")]
        public bool HasProfDev { get; set; }

        public UserProfile userProfile { get; set; }

        public int UserProfileId { get; set; }
    }
}