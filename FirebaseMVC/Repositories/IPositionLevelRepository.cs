using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IPositionLevelRepository
    {
        List<Positionlevel> GetPositionLevels();
    }
}