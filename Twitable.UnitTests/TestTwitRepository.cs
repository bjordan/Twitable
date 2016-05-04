using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitable.EntityManager.Filter;
using Twitable.EntityRepository;
using Twitable.Repository.Interfaces;
using Twitable.Utils;

namespace Twitable.UnitTests
{
    /// <summary>
    /// Tests ITwitRepository Methods
    /// </summary>
    [TestClass]
    public class TestTwitRepository
    {

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "File contents invalid")]
        public void GetAllTwits()
        {
            ITwitRepository twitRepository = new TwitRepository(Path.Combine(Config.SourceDirectory, Config.Tweets));

            var twitList = twitRepository.GetAll();
            Assert.AreEqual(twitList.Count(), 3);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "File contents invalid")]
        public void GetTwitByFilter()
        {
            ITwitRepository twitRepository = new TwitRepository(Path.Combine(Config.SourceDirectory, Config.Tweets));

            var twitList = twitRepository.GetByFilter(new TwitFilter { UserName = "Alan" });
            Assert.AreEqual(twitList.Count(), 2);
        }
    }
}
