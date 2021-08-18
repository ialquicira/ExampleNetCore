using Example.Domain;
using System;
using System.Linq;

namespace Example.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAllEmployees();

        void CreateEmployee(Employee domain);

        void DeleteEmployee(Guid employeeId);

        Employee GetEmployeeById(Guid employeeId);

        void UpdateEmployee(Employee domain);
    }
}
