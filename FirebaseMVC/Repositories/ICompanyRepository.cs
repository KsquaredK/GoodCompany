using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanies();
        List<Company> GetCompaniesByUser(int id, int userId);
        Company GetCompanyById(int id, int userId);
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);
    }
}