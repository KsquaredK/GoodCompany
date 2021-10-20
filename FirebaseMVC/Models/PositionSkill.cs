using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Models
{
    public class PositionSkill
    {
        public int Id { get; set; }

        public int PositionId { get; set;  }

        public int SkillId { get; set; }
    }
}
