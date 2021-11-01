using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models.ViewModels
{
    public class ApplicationSkillsViewModel
    {
        public Application Application { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
