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
    public class UserTest
    {

        [TestMethod]
        public void CreateUser()
        {
            new UsersController().Create(
                new User
                {
                    Login = "l",
                    Password = new byte[1] {0},
                    ContactID = 2,
                    LastLoginTime = DateTime.Now,
                }
                );
        }
        [TestMethod]
        public void EditUser()
        {
            new UsersController().Edit(
        new User
        {
            UserID = 3,
            Login = "dgdfl",
            Password = new byte[1] { 0 },
            ContactID = 1,
            LastLoginTime = DateTime.Now,
        }
        );
        }
        [TestMethod]
        public void GetByIdUser()
        {
            new UsersController().Get(3);
        }
        [TestMethod]
        public void GetUser()
        {
            new UsersController().Get();
        }
        [TestMethod]
        public void DeleteUser(int id)
        {
            new UsersController().Delete(3);
        }

    }
}
