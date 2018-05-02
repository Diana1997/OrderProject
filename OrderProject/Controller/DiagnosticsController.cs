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
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Create(Diagnostic diagnostic)
        {
            db.Diagnostics.Add(diagnostic);
            db.SaveChanges();
        }
        public void Edit(Diagnostic diagnostic)
        {
            db.Entry(diagnostic).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Diagnostic diagnostic = db.Diagnostics.Find(id);
            db.Diagnostics.Remove(diagnostic);
            db.SaveChanges();
        }
    }
}
