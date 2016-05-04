using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitable.BusinessRuleEngine;
using Twitable.Utils;

namespace Twitable.UnitTests
{
    /// <summary>
    /// Summary description for TestTwitManager
    /// </summary>
    [TestClass]
    public class TestTwitManager
    { 

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetTwits()
        {
            var tm = new TwitManager(Path.Combine(Config.SourceDirectory, Config.UserFile), Path.Combine(Config.SourceDirectory, Config.Tweets));
            var output = tm.LoadTweets(); 
            foreach (var ut in output)
            {
                Debug.WriteLine(ut.Username); 
                foreach (var twit in ut.Twits)
                { 
                    Debug.WriteLine("\t@{0}: {1}{2}", twit.UserName, twit.Text, Environment.NewLine);
                }
            }
        }
    }
}
