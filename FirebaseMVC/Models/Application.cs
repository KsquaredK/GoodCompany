using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class Application
    {
        public int Id { get; set; }

        public int PositionId { get; set; }

        public int UserProfileId { get; set; }

        public DateTime DateApplied { get; set; }

        public string NextAction { get; set; }

        public DateTime NextActionDue { get; set; }

        public string RecommenderNotes { get; set; }

    }
}
 