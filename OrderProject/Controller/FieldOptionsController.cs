using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class FieldOptionsController
    {

        public void Create(FieldOption fieldOption)
        {
            using (var db = new ApplicationDbContext())
            {
                db.FieldOptions.Add(fieldOption);
                db.SaveChanges();
            }
        }
        public void Edit(FieldOption fieldOption)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(fieldOption).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                FieldOption fieldOption = db.FieldOptions.Find(id);
                db.FieldOptions.Remove(fieldOption);
                db.SaveChanges();
            }
        }

        public FieldOption Get(int id)
        {
            using (var db = new ApplicationDbContext())
              return db.FieldOptions.Find(id);
        }
        public IList<FieldOption> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.FieldOptions.ToList();
        }
    }
}
