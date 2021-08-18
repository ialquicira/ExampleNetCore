using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Model
{
    public class BeneficiaryView
    {
        public Guid BeneficiaryId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Relationship { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
