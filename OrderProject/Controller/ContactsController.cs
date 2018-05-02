using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ContactsController : IDisposable
    {
        private ApplicationDbContext db;
        public ContactsController()
        {
            db = new ApplicationDbContext();
        }
        public void Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }
        public void Edit(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }
        public Contact Get(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }
        public IList<Contact> Get()
        {
            return db.Contacts.ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
