using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class UsersController : IDisposable
    {
        private ApplicationDbContext db;
        public UsersController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void Edit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public User Get(int id)
        {
            return db.Users.Include(u => u.Contact).Include(u => u.Diagnostic).First();
        }
        public IList<User> Get()
        {
            return db.Users.Include(u => u.Contact).Include(u => u.Diagnostic).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
