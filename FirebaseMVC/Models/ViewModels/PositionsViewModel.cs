using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models.ViewModels
{
    public class PositionsViewModel
    {
        public Position Position { get; set; }
        public List<Company> Company { get; set; }
        public List<Application> Application { get; set; }
    }
}
