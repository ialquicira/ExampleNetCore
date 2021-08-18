using Example.Data;
using Example.Domain;
using System;
using System.Linq;

namespace Example.Services
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IDbContext _dbContext;
        private readonly IRepository<Beneficiary> _beneficiaryRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public BeneficiaryService(
            IRepository<Beneficiary> beneficiaryRepository,
            IRepository<Employee> employeeRepository,
            IDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._beneficiaryRepository = beneficiaryRepository;
            this._employeeRepository = employeeRepository;
        }

        public void CreateBeneficiary(Beneficiary domain)
        {
            _beneficiaryRepository.Create(domain, Guid.NewGuid().ToString());
            _beneficiaryRepository.Save();
        }

        public void DeleteBeneficiary(Guid beneficiaryId)
        {
            _beneficiaryRepository.Delete(beneficiaryId, Guid.NewGuid().ToString());
            _beneficiaryRepository.Save();
        }

        public IQueryable<Beneficiary> GetAllBeneficiaries()
        {
            var query = (from b in _beneficiaryRepository.GetAll()
                         join e in _employeeRepository.Table
                         on b.EmployeeId equals e.EmployeeId
                         select b);
            return query;
        }

        public Beneficiary GetBeneficiaryById(Guid beneficiaryId)
        {
            return _beneficiaryRepository.Get(beneficiaryId);
        }

        public void UpdateBeneficiary(Beneficiary domain)
        {
            _beneficiaryRepository.Update(domain, Guid.NewGuid().ToString());
            _beneficiaryRepository.Save();
        }
    }
}
