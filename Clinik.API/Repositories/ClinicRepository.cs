using System.Collections.Generic;
using Clinik.API.Entities;

namespace Clinik.API.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private static List<Clinic> clinicList = new List<Clinic>();

        public Clinic getClinicById(int clinicId)
        {
            return clinicList.Find(clinic => clinic.clinicId == clinicId);
        }

        public void addClinic(Clinic clinic){
            if(clinic == null){
                return;
            }
            clinicList.Add(clinic);
        }

        public List<Clinic> getAllClinics()
        {
            return clinicList ?? null;
        }

    }
}