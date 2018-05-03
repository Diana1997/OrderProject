using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class DiagnosticsController
    {
        public void Create(Diagnostic diagnostic)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Diagnostics.Add(diagnostic);
                db.SaveChanges();
            }
        }
        public void Edit(Diagnostic diagnostic)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(diagnostic).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Diagnostic diagnostic = db.Diagnostics.Find(id);
                db.Diagnostics.Remove(diagnostic);
                db.SaveChanges();
            }
        }
        public Diagnostic Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Diagnostics.Find(id);

        }
        public IList<Diagnostic> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Diagnostics.ToList();
        }
    }
}
