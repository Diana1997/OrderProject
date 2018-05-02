using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class FieldOptionsController : IDisposable
    {
        private ApplicationDbContext db;
        public FieldOptionsController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(FieldOption fieldOption)
        {
            db.FieldOptions.Add(fieldOption);
            db.SaveChanges();
        }
        public void Edit(FieldOption fieldOption)
        {
            db.Entry(fieldOption).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            FieldOption fieldOption = db.FieldOptions.Find(id);
            db.FieldOptions.Remove(fieldOption);
            db.SaveChanges();
        }

        public FieldOption Get(int id)
        {
            FieldOption fieldOption = db.FieldOptions.Find(id);
            return fieldOption;
        }
        public IList<FieldOption> Get()
        {
            return db.FieldOptions.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
