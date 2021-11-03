using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GoodCompanyMVC.Repositories;
using GoodCompanyMVC.Models;
using GoodCompanyMVC.Models.ViewModels;

namespace GoodCompanyMVC.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly IApplicationRepository _applicationRepo;
        private readonly ICompanyRepository _companyRepo;
        private readonly IUserProfileRepository _userRepo;
        private readonly ISkillRepository _skillRepo;
        private readonly IPositionLevelRepository _positionLevelRepo;
        private readonly IApplicationNoteRepository _applicationNoteRepo;

        public ApplicationController(IApplicationRepository applicationRepository, 
        IUserProfileRepository userRepository, ICompanyRepository companyRepository,
        IApplicationNoteRepository applicationNoteRepository, IPositionLevelRepository positionLevelRepository,
        ISkillRepository skillRepository)
        {
            _applicationRepo = applicationRepository;
            _companyRepo = companyRepository;
            _userRepo = userRepository;
            _skillRepo = skillRepository;
            _positionLevelRepo = positionLevelRepository;
            _applicationNoteRepo = applicationNoteRepository;
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
            var application = _applicationRepo.GetApplicationById(id);
            if (application == null)
            {
                return NotFound();
            }
            application.Skills = _skillRepo.GetSkillsByApplication(application.Id);
            var vm = new ApplicationViewModel()
            {
                Application = application,
                Skills = _skillRepo.GetSkills()
            };
            return View(vm);
        }

        // GET: ApplicationController/Create
        public ActionResult Create()
        {
            List<Company> companies = _companyRepo.GetCompanies();
            List<PositionLevel> positionLevels = _positionLevelRepo.GetPositionLevels();
            List<Skill> skills = _skillRepo.GetSkills();

            ApplicationFormViewModel vm = new ApplicationFormViewModel()
            {
                Application = new Application(),
                CompanyOptions = companies,
                PositionLevelOptions = positionLevels,
                Skills = skills
                //multiselect^^ ChosenSkills property holds array of ints of skillIds
            };


            return View(vm);
        }

        // POST: ApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationFormViewModel vm)
        {
            try
            {
                vm.Application.UserProfileId = GetCurrentUserId();
                _applicationRepo.AddApplication(vm.Application);

                return RedirectToAction("UserIndex");

            }
            catch (Exception ex)
                {
                return View(vm);
            }
        }


        // GET: ApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            List<Company> companies = _companyRepo.GetCompanies();
            List<PositionLevel> positionLevels = _positionLevelRepo.GetPositionLevels();
            List<Skill> skills = _skillRepo.GetSkills();

            ApplicationFormViewModel vm = new ApplicationFormViewModel()
            {
                Application = _applicationRepo.GetApplicationById(id),
                CompanyOptions = companies,
                PositionLevelOptions = positionLevels,
                Skills = skills
            };

            if (vm == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: ApplicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ApplicationFormViewModel vm)
        {
            try
            {
                _applicationRepo.UpdateApplication(vm.Application);
                return RedirectToAction("UserIndex");
            }
            catch (Exception ex)
            {
                return View(vm);
            }
        }

        // GET: ApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            Application application = _applicationRepo.GetApplicationById(id);
            return View(application);
        }

        // POST: ApplicationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Application application)
        {
            Application Application = _applicationRepo.GetApplicationById(id);
            try
            {
                _applicationRepo.DeleteApplication(id);
                return RedirectToAction("UserIndex");
            }
            catch (Exception ex)
            {
                return View(application);
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
