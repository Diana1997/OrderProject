using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProject.Controller;
using OrderProject.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class ContactTest
    {

        [TestMethod]
        public void CreateContact()
        {
            new ContactsController().Create(
                new Contact
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
                }
                );
        }
        [TestMethod]
        public void EditContact()
        {
            new ContactsController().Edit(
                new Contact
                {
                    ContactID = 1,
                    Firstname = "f",
                    Secondname = "s",
                    Lastname = "l",
                    Gender = Gender.Mail,
                    Birthday = DateTime.Now,
                    Phone = "45454",
                    Email = "email@gmail.com",
                    Address = "a",
                    Position = "p",
                    Specialty = "s",
                    Education = "e",
                    Comment = "c",
                    Degree = "D",
                }
                );
        }
        [TestMethod]
        public void GetByIdContact()
        {
            new ContactsController().Get(1);
        }
        [TestMethod]
        public void GetContact()
        {
            new ContactsController().Get();
        }
        [TestMethod]
        public void DeleteContact(int id)
        {
            new ContactsController().Delete(1);
        }

    }
}
