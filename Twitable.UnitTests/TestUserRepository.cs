using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitable.RepositoryManager;
using Twitable.RepositoryManager.Interfaces;

namespace Twitable.UnitTests
{
    [TestClass]
    public class TestUserRepository
    {
        [TestMethod]
        public void GetAllUsers()
        { 
            IUserRepository rep = new UserRepository();
            var userList = rep.GetAll();

        }
    }
}
