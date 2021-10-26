using GoodCompanyMVC.Models;
using GoodCompanyMVC.Repositories;
using GoodCompanyMVC.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoodCompanyMVC.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionRepository _positionRepo;
        private readonly ICompanyRepository _companyRepo;


        public PositionController(
            IPositionRepository ownerRepository,
            ICompanyRepository companyRepository
            )

        {
            _positionRepo = ownerRepository;
            _companyRepo = companyRepository;
        }

        // GET: PositionController
        public ActionResult Index()
        {
            int userId = GetCurrentUserId();

            List<Position> positions = _positionRepo.GetAllPositionsByCurrentUser(userId);
            return View();
        }

        // GET: PositionController1/Details/5
        public ActionResult Details(int id)
        {
            int userId = GetCurrentUserId();
            Position position = _positionRepo.GetPositionById(id);
            List<Company> companies = _companyRepo.GetCompaniesByUser(userId);

            var vm = new PositionsViewModel()
            {
                Position = position,
                Company = companies
            };
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Method for getting current user by id:
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
