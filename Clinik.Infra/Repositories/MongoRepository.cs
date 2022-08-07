using System;
using System.Collections.Generic;
using Clinik.Domain.Entities;
using Clinik.Infra.Database;
using MongoDB.Driver;

namespace Clinik.Infra.Repositories
{
    public class MongoRepository : IClinicRepository
    {
        private IMongoDBContext _dbContext;
        public MongoRepository(IMongoDBContext mongoDBContext)
        {
            this._dbContext = mongoDBContext;
        }

        public List<Clinic> GetAllClinics()
        {
            return this.GetClinicsFromDatabase().AsQueryable().ToList<Clinic>() ?? null;
        }

        public Clinic AddClinic(Clinic clinic)
        {
            clinic.patients.RemoveAll(patient => true);
            IMongoCollection<Clinic> dbClinic = this.GetClinicsFromDatabase();
            clinic._id = this.GetAutoIncrementFromClinicCounter("clinicId");
            dbClinic.InsertOne(clinic);
            return this.GetClinicById((int)clinic._id);
        }

        public Clinic GetClinicById(int clinicId)
        {
            List<Clinic> clinics = this.GetAllClinics();
            if (clinics == null)
            {
                return null;
            }
            return clinics.Find(clinic => clinic._id == clinicId);
        }

        public Clinic UpdateClinicById(int clinicId, Clinic clinic)
        {
            IMongoCollection<Clinic> dbClinic = this.GetClinicsFromDatabase();
            clinic._id = clinicId;
            dbClinic.FindOneAndReplace<Clinic>(clinic => clinic._id == clinicId, clinic);
            return this.GetClinicById((int)clinic._id);
        }

        public bool DeleteClinicById(int clinicId)
        {
            IMongoCollection<Clinic> dbClinic = this.GetClinicsFromDatabase();
            Clinic deletedClinic = dbClinic.FindOneAndDelete<Clinic>(clinic => clinic._id == clinicId);
            return deletedClinic != null;
        }

        public List<Patient> GetAllPatientsByClinicId(int clinicId)
        {
            List<Clinic> clinics = this.GetAllClinics();
            if (clinics == null)
            {
                return null;
            }
            Clinic clinicToSearch = clinics.Find(clinic => clinic._id == clinicId);
            if(clinicToSearch == null)
            {
                return null;
            }
            return clinicToSearch.GetAllPatients() ?? null;
        }

        public Patient GetPatientByClinicIdAndPatientId(int clinicId, int patientId)
        {
            Clinic searchedClinic = this.GetClinicById(clinicId);
            if(searchedClinic == null)
            {
                return null;
            }
            return searchedClinic.patients.Find(patient => patient._id == patientId);
        }
        
        public Patient AddPatient(int clinicId, Patient patient)
        {
            Clinic clinicToInsert = this.GetClinicById(clinicId);
            if(clinicToInsert == null)
            {
                return null;
            }
            patient._id = this.GetAutoIncrementFromClinicCounter("patientId");
            clinicToInsert.SetSinglePatient(patient);
            IMongoCollection<Clinic> dbClinic = this.GetClinicsFromDatabase();
            Clinic clinicAfterInsert = dbClinic.FindOneAndReplace<Clinic>(clinic => clinic._id == clinicId, clinicToInsert);
            return clinicAfterInsert == null ? null : patient;
        }

        public Patient UpdatePatientById(int clinicId, int patientId, Patient patient)
        {
            Clinic clinicToUpdate = this.GetClinicById(clinicId);
            if(clinicToUpdate == null)
            {
                return null;
            }
            Patient patientToUpdate = clinicToUpdate.GetPatientById(patientId);
            if(patientToUpdate == null)
            {
                return null;
            }
            patient._id = patientId;
            clinicToUpdate.patients[clinicToUpdate.patients.FindIndex(patientToSearch => patientToSearch._id == patientId)] = patient;
            IMongoCollection<Clinic> dbClinic = this.GetClinicsFromDatabase();
            Clinic clinicAfterUpdate = dbClinic.FindOneAndReplace<Clinic>(clinic => clinic._id == clinicId, clinicToUpdate);
            return clinicAfterUpdate == null ? null : patient;
        }

        public bool DeletePatientById(int clinicId, int patientId)
        {
            Clinic clinicToUpdate = this.GetClinicById(clinicId);
            if(clinicToUpdate == null)
            {
                return false;
            }
            Patient patientToDelete = clinicToUpdate.GetPatientById(patientId);
            if(patientToDelete == null)
            {
                return false;
            }
            clinicToUpdate.patients.RemoveAll(patient => patient._id == patientId);
            IMongoCollection<Clinic> dbClinic = this.GetClinicsFromDatabase();
            dbClinic.FindOneAndReplace<Clinic>(clinic => clinic._id == clinicId, clinicToUpdate);
            return this.GetPatientByClinicIdAndPatientId(clinicId, patientId) == null;
        }

        private IMongoCollection<Clinic> GetClinicsFromDatabase()
        {
            return this._dbContext.GetCollection<Clinic>("Clinic");
        }

        private int GetAutoIncrementFromClinicCounter(string property)
        {
            IMongoCollection<ClinicCounter> collection = this._dbContext.GetCollection<ClinicCounter>("ClinicCounter");
            ClinicCounter counter = collection.Find<ClinicCounter>(count => true).First<ClinicCounter>();
            counter.GetType().GetProperty(property).SetValue
            (
                counter,
                (Convert.ToInt32(counter.GetType().GetProperty(property).GetValue(counter)) + 1)
            );
            collection.FindOneAndReplace<ClinicCounter>(count => true, counter);
            return Convert.ToInt32(counter.GetType().GetProperty(property).GetValue(counter));
        }
    }
}