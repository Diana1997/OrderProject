using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ResearchesController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Create(Research research)
        {
            db.Researchs.Add(research);
            db.SaveChanges();
        }
        public void Edit(Research research)
        {
            db.Entry(research).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Research research = db.Researchs.Find(id);
            db.Researchs.Remove(research);
            db.SaveChanges();
        }
    }
}
