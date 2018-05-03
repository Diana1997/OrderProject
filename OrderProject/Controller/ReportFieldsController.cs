using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ReportFieldsController 
    {
        public void Create(ReportField reportField)
        {
            using (var db = new ApplicationDbContext())
            {
                db.ReportFields.Add(reportField);
                db.SaveChanges();
            }
        }
        public void Edit(ReportField reportField)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(reportField).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                ReportField reportField = db.ReportFields.Find(id);
                db.ReportFields.Remove(reportField);
                db.SaveChanges();
            }
        }
        public ReportField Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.ReportFields.Include(r => r.FieldOption).First();
        }
        public IList<ReportField> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.ReportFields.Include(r => r.FieldOption).ToList();
        }
    }
}
