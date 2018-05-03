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
        public void Create(Research research)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Researchs.Add(research);
                db.SaveChanges();
            }
        }
        public void Edit(Research research)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(research).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Research research = db.Researchs.Find(id);
                db.Researchs.Remove(research);
                db.SaveChanges();
            }
        }
    }
}
