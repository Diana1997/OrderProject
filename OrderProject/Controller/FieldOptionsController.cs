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
        ApplicationDbContext db { get; set; }

        public FieldOptionsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(FieldOption fieldOption)
        {
            db.FieldOptions.Add(fieldOption);
            db.SaveChanges();
            return fieldOption.FieldOptionID;
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
            return db.FieldOptions.Find(id);
        }
        public IList<FieldOption> Get()
        {
            return db.FieldOptions.ToList();
        }
    }
}
