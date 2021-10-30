using GoodCompanyMVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using GoodCompanyMVC.Models;
using System.Linq;
using System;



namespace GoodCompanyMVC.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly IApplicationRepository _applicationRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly IUserProfileRepository _userRepo;


        public ApplicationController(IApplicationRepository applicationRepository, 
        IUserProfileRepository userRepository, ICompanyRepository companyRepository)
        {
            _applicationRepo = applicationRepository;
            _companyRepo = companyRepository;
            _userRepo = userRepository;
        }

        // GET: ApplicationController
        public ActionResult Index()
        {
            List<Application> applications = _applicationRepo.GetApplications();

            return View(applications);
        }

        public IActionResult UserIndex()
        {
            int userId = GetCurrentUserId();
            var applications = _applicationRepo.GetApplicationsByCurrentUser(userId);

            return View(applications);
        }

        // GET: ApplicationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application application)
        {
            try
            {
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Application application)
        {
            try
            {
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Application application)
        {
            try
            {
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
