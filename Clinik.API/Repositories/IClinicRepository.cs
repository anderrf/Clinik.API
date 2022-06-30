using System.Collections.Generic;
using Clinik.API.Entities;

namespace Clinik.API.Repositories
{
    public interface IClinicRepository
    {
        
        public Clinic getClinicById(int clinicId);

        public void addClinic(Clinic clinic);

        public List<Clinic> getAllClinics();

    }
}