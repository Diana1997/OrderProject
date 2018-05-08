using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;

namespace UnitTestProjectTest
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void ContactTest1()
        {
            Contact  contact;
            int id;
            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ContactsController(db);
                contact = new Contact
                {
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Femail,
                    Birthday = DateTime.Now,
                    Phone = "45454",
                    Email = "email@gmail.com",
                    Address = "a",
                    Position = "p",
                    Specialty = "s",
                    Education = "e",
                    Comment = "c",
                    Degree = "D",
                };

                id = ctrl.Create(contact);
                var contactRes = ctrl.Get(id);
                Assert.IsNotNull(contact);
                Assert.AreEqual("f", contactRes.Firstname);
                Assert.AreEqual("s", contactRes.Secondname);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ContactsController(db);
                contact = new Contact
                {
                    ContactID = id,
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Femail,
                    Birthday = DateTime.Now,
                    Phone = "45454",
                    Email = "email@gmail.com",
                    Address = "a",
                    Position = "p",
                    Specialty = "s",
                    Education = "e",
                    Comment = "c",
                    Degree = "D",
                };
                ctrl.Edit(contact);
                var contactRes = ctrl.Get(id);
                Assert.IsNotNull(contact);
                Assert.AreEqual("f", contactRes.Firstname);
                Assert.AreEqual("s", contactRes.Secondname);
            }

            using (var db = new ApplicationDbContext())
            {
                var ctrl = new ContactsController(db);

                ctrl.Delete(contact.ContactID);

                // check results
                var contactRes = ctrl.Get(id);

                Assert.IsNull(contactRes);
            }
        }
    }
}
