using GoodCompanyMVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using GoodCompanyMVC.Models;
using System.Linq;
using System;

//Controller classes handle incoming HTTP requests.
//They can validate the user, validate request data,
//query the database, contain logic for manipulating
//the data, and generate an HTML response.

namespace GoodCompanyMVC.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        //dependency injection of repo
        private readonly ICompanyRepository _companyRepo;

        //constructor for class
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepo = companyRepository;
        }

        // GET: Handles http GET request
        public ActionResult Index()
        {
            List<Company> companies = _companyRepo.GetCompanies();      
            return View(companies);
        }

        public ActionResult UserIndex()
        {
            int userId = GetCurrentUserId();
            var companies = _companyRepo.GetCompaniesByUser(userId);
            return View(companies);
        }

        // GET: CompanyController/Details/5
        //When the ASP.NET framework invokes this method for us,
        //it will take whatever value is in the url and pass it in.
        public ActionResult Details(int id)
        {
            int userId = GetCurrentUserId();
            Company company = _companyRepo.GetCompanyById(id, userId);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        //The ASP.NET framework binds values it gets 
        //from html forms fields to C# objects.
        public ActionResult Create(Company company)
        {
            List<Company> companies = _companyRepo.GetCompanies(); 
            if (companies.Any(companies => companies.Name == company.Name))
            {
                ModelState.AddModelError("", "Company already exists.");
                return View(company);
            }
            else
            {
                try
                {
                    _companyRepo.AddCompany(company);
//Redirect to updated list view
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
//Or, if submission fails, return to empty form view
                    return View(company);
                }
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            Company company = _companyRepo.GetCompanyById(id, GetCurrentUserId());
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Company company)
        {

                _companyRepo.UpdateCompany(company);
                    return RedirectToAction("UserIndex");

        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            int userId = GetCurrentUserId();
            Company company = _companyRepo.GetCompanyById(id, userId);
            return View(company);
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Company company)
        {
            try
            {
                _companyRepo.DeleteCompany(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
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
