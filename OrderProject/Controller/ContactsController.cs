using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ContactsController
    {
        public void Create(Contact contact)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
        }
        public void Edit(Contact contact)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Contact contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }
        public Contact Get(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Contact contact = db.Contacts.Find(id);
                return contact;
            }
        }
        public IList<Contact> Get()
        {
            using (var db = new ApplicationDbContext())
                return db.Contacts.ToList();

        }
    }
}
