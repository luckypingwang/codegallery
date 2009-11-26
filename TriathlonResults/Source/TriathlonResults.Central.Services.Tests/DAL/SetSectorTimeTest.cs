﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using TriathlonResults.Central.Services.DAL;
using TriathlonResults.Entities;
using System.Data.SqlClient;
using System.Data;
using TriathlonResults.Central.Services.Tests.Helpers;
namespace TriathlonResults.Central.Services.Tests
{
    /// <summary>
    ///This is a test class for TriathlonResults.Central.Services.DAL.SetSectorTime and is intended
    ///to contain all TriathlonResults.Central.Services.DAL.SetSectorTime Unit Tests
    ///</summary>
    [TestClass()]
    public class SetSectorTimeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Execute ()
        ///</summary>
        [TestMethod()]
        public void Execute()
        {
            //input new record:
            SetSectorTime target = new SetSectorTime();
            target.RaceId = 1;
            target.SectorId = Sector.Swim;
            target.AthleteId = new Random().Next();
            target.StartTime = new DateTime(2008, 09, 19, 12, 00, 00);
            target.EndTime = new DateTime(2008, 09, 19, 12, 20, 20);
            SectorTime.CalculateDuration(target.StartTime, target.EndTime);
            target.Execute();

            //ensure result available:
            string sqlCommand = string.Format(TestSQL.TriathlonResult.SectorTimes.GetDurationFormat, target.RaceId, target.SectorId, target.AthleteId);
            int duration = TestDataHelper.GetScalar<int>(sqlCommand);
            Assert.AreEqual<int>(target.Duration, duration);
        }

        [TestMethod()]
        public void Execute_NoDates()
        {
            //input new record:
            SetSectorTime target = new SetSectorTime();
            target.RaceId = 1;
            target.SectorId = Sector.Swim;
            target.AthleteId = new Random().Next();
            target.Duration = 955;
            target.Execute();

            //ensure result available:
            string sqlCommand = string.Format(TestSQL.TriathlonResult.SectorTimes.GetDurationFormat, target.RaceId, target.SectorId, target.AthleteId);
            int duration = TestDataHelper.GetScalar<int>(sqlCommand);
            Assert.AreEqual<int>(target.Duration, duration);
        }


    }


}