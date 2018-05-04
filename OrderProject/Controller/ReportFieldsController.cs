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
        ApplicationDbContext db { get; set; }

        public ReportFieldsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(ReportField reportField)
        {
            db.ReportFields.Add(reportField);
            db.SaveChanges();
            return reportField.ReportFieldID;
        }
        public void Edit(ReportField reportField)
        {
            db.Entry(reportField).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            ReportField reportField = db.ReportFields.Find(id);
            db.ReportFields.Remove(reportField);
            db.SaveChanges();
        }
        public ReportField Get(int id)
        {
            return db.ReportFields.Include(r => r.FieldOption).First();
        }
        public IList<ReportField> Get()
        {
            return db.ReportFields.Include(r => r.FieldOption).ToList();
        }
    }
}
