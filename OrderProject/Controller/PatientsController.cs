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
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Create(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
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
    }
}
