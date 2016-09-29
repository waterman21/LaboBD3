using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;

namespace Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
       /* [TestMethod]
        public void TestMethod1()
        {
        }
        */
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DBInitializer());
            using (CompanyContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        [TestMethod]
        public void InsertionFonctionnelle()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(1, context.Customers.ToList().Count);
            }
        }

        public CompanyContext GetContext()
        {
            return new CompanyContext();
        }
    }
}
