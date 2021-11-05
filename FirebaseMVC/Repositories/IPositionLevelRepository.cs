using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IPositionLevelRepository
    {
        void AddPositionLevel(PositionLevel positionLevel);
        void DeletePositionLevel(int id);
        PositionLevel GetPositionLevelByApplication(int applicationId);
        void GetPositionLevelById(int id);
        List<PositionLevel> GetPositionLevels();
        void GetPositionLevelsByCurrentUser(int userProfileId);
        void UpdatePositionLevel(PositionLevel positionLevel);
    }
}