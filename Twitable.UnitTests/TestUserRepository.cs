using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitable.EntityManager.Filter;
using Twitable.EntityRepository;
using Twitable.Repository.Interfaces;
using Twitable.Utils;

namespace Twitable.UnitTests
{
    [TestClass]
    public class TestUserRepository
    {
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "File contents invalid")]
        public void GetAllUsers()
        {
            IUserRepository rep = new UserRepository(Path.Combine(Config.SourceDirectory, Config.UserFile));
            var userList = rep.GetAll();
         Assert.AreEqual(userList.Count() ,3);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "File contents invalid")]
        public void GetAllFollowers()
        {
            IUserRepository rep = new UserRepository(Path.Combine(Config.SourceDirectory, Config.UserFile));
            var userList = rep.GetAll();
            var followers = new List<string>();
            foreach (var user in userList)
            {
                var temp = rep.GetByFilter(new UserFilter { Following = user.UserName });
                followers.AddRange(temp.Select(ux => ux.UserName));
            }
            Assert.AreEqual(followers.Distinct().Count(), 2);

        }
    }
}
