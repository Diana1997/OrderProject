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
        ApplicationDbContext db { get; set; }

        public DiagnosticsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Diagnostic diagnostic)
        {
            db.Diagnostics.Add(diagnostic);
            db.SaveChanges();
            return diagnostic.DiagnosticID;
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
        public Diagnostic Get(int id)
        {
            return db.Diagnostics.Find(id);

        }
        public IList<Diagnostic> Get()
        {
            return db.Diagnostics.ToList();
        }
    }
}
