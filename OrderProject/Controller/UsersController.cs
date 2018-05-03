using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class UsersController 
    {
        public void Create(User user)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public void Edit(User user)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public User Get(int id)
        {
            using (var db = new ApplicationDbContext())
                return db.Users.Include(u => u.Contact).Include(u => u.Diagnostic).First();
        }
        public IList<User> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Users.Include(u => u.Contact).Include(u => u.Diagnostic).ToList();
        }
    }
}
