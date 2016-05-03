using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitable.RepositoryManager;
using Twitable.RepositoryManager.Interfaces;
using Twitable.Utils;

namespace Twitable.UnitTests
{
    [TestClass]
    public class TestUserRepository
    {
        [TestMethod]
        public void GetAllUsers()
        {
            IUserRepository rep = new UserRepository(Path.Combine(Config.SourceDirectory, Config.UserFile));
            var userList = rep.GetAll();

        }
    }
}
