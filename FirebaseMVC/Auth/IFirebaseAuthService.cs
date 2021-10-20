using System.Threading.Tasks;
using GoodCompanyMVC.Auth.Models;

namespace GoodCompanyMVC.Auth
{
    public interface IFirebaseAuthService
    {
        Task<FirebaseUser> Login(Credentials credentials);
        Task<FirebaseUser> Register(Registration registration);
    }
}