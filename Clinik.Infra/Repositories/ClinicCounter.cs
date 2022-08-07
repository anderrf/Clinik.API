using MongoDB.Bson;

namespace Clinik.Infra.Repositories
{
    public class ClinicCounter
    {
        public ObjectId _id {get; set;}
        public int clinicId {get; set;}
        public int patientId {get; set;}

        public ClinicCounter(){}
    }
}