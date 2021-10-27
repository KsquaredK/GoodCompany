using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }

        public List<Company> Company { get; set; }

        public List<Position> Position { get; set; }

        public List<Skill> Skill { get; set; }

        public List<UserProfile> UserProfile { get; set; }


    }
}
