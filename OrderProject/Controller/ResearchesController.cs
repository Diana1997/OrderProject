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
        ApplicationDbContext db { get; set; }

        public ResearchesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Research research)
        {
            db.Researchs.Add(research);
            db.SaveChanges();
            return research.ResearchID;
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

        public Research Get(int id)
        {
            return db.Researchs.Find(id);
        }
    }
}
