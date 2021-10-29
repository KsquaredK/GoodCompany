using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class ApplicationNote
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public Application application { get; set; }

        public string Note { get; set; }
    }
}
