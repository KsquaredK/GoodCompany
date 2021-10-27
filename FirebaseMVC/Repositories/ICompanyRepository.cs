using GoodCompanyMVC.Models;
using System.Collections.Generic;

namespace GoodCompanyMVC.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanies();

        List<Company> GetCompaniesByCurrentUser(int userId);

        Company GetCompanyById(int id);

        void AddCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(int id);
    }
}