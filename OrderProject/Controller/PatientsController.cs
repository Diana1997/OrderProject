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
        public void Create(Patient patient)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }
        public void Edit(Patient patient)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Patient patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }
        public Patient Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Patients.Include(p => p.Contact).Include(p => p.Image).First();
        }
        public IList<Patient> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Patients.Include(p => p.Contact).Include(p => p.Image).ToList();
        }
    }
}
