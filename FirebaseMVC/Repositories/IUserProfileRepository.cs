using GoodCompanyMVC.Models;

namespace GoodCompanyMVC.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetById(int id);
    }
}