using Example.Data;
using Example.Domain;
using System;
using System.Linq;

namespace Example.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbContext _dbContext;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository,
            IDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._employeeRepository = employeeRepository;
        }
        public void CreateEmployee(Employee domain)
        {
            _employeeRepository.Create(domain, Guid.NewGuid().ToString());
            _employeeRepository.Save();
        }

        public void DeleteEmployee(Guid employeeId)
        {
            _employeeRepository.Delete(employeeId, Guid.NewGuid().ToString());
            _employeeRepository.Save();
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return _employeeRepository.Get(employeeId);
        }

        public void UpdateEmployee(Employee domain)
        {
            _employeeRepository.Update(domain, Guid.NewGuid().ToString());
            _employeeRepository.Save();
        }
    }
}
