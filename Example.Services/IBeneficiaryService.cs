using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Services
{
    public interface IBeneficiaryService
    {
        IQueryable<Beneficiary> GetAllBeneficiaries();

        void CreateBeneficiary(Beneficiary domain);

        void DeleteBeneficiary(Guid beneficiaryId);

        Beneficiary GetBeneficiaryById(Guid beneficiaryId);

        void UpdateBeneficiary(Beneficiary domain);
    }
}
