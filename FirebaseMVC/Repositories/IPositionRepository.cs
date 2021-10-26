using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface IPositionRepository
    {
        List<Position> GetPositions();
        List<Position> GetAllPositionsByCurrentUser(int UserProfileId);
        Position GetPositionById(int id);
        void AddPosition(Position position);
        void UpdatePosition(Position position);
        List<Position> DeletePosition(int id);
    }
}