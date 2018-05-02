using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class StatisticalSettingsController : IDisposable
    {
        private ApplicationDbContext db;
        public StatisticalSettingsController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(StatisticalSettings statisticalSettings)
        {
            db.StatisticalSettings.Add(statisticalSettings);
            db.SaveChanges();
        }
        public void Edit(StatisticalSettings statisticalSettings)
        {

            db.Entry(statisticalSettings).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            StatisticalSettings statisticalSettings = db.StatisticalSettings.Find(id);
            db.StatisticalSettings.Remove(statisticalSettings);
            db.SaveChanges();
        }

        public StatisticalSettings Get(int id)
        {
            return db.StatisticalSettings.Find(id);
        }
        public IList<StatisticalSettings> Get()
        {
            return db.StatisticalSettings.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
