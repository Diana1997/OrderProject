using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class PatientsController 
    {
        ApplicationDbContext db { get; set; }
        public PatientsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            return patient.PatientID;
        }
        public void Edit(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void Delete(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }
        public Patient Get(int id)
        {
                return db.Patients.Include(p => p.Contact).Include(p => p.Image).FirstOrDefault(x => x.PatientID == id);
        }
        public IList<Patient> Get()
        {
                return db.Patients.Include(p => p.Contact).Include(p => p.Image).ToList();
        }
    }
}
