using System;

namespace Example.Domain
{
    public class Employee : Entity
    {
        public Guid EmployeeId { get; set; }
        public string Photography { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Workstation { get; set; }
        public decimal Salary { get; set; }
        public bool Status { get; set; }
        public DateTime HiringDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

    }
}
