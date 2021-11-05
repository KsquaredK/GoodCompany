using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoodCompanyMVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GoodCompanyMVC.Repositories;

namespace GoodCompanyMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IApplicationRepository _applicationRepository;

        public HomeController(IUserProfileRepository userProfileRepository, IApplicationRepository applicationRepository)
        {
            _userProfileRepository = userProfileRepository;
            _applicationRepository = applicationRepository;
        }

        public IActionResult Index()
        {
            var userProfileId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userProfile = _userProfileRepository.GetById(userProfileId);
            return View(userProfile);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
