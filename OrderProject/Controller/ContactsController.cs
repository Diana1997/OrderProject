using OrderProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Controller
{
    public class ContactsController
    {
        ApplicationDbContext db { get; set; }

        public ContactsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public int Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return contact.ContactID;
        }
        public void Edit(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
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
    }
}
