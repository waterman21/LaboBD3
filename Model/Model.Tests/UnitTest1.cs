using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;

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


        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetecterLesEditionsConcurrentes()
        {
            using (CompanyContext context1 = GetContext())
            {
                using (CompanyContext context2 = GetContext())
                {
                    var client1 = context1.Customers.First();
                    var client2 = context2.Customers.First();

                    client1.AccountBalance += 1000;
                    context1.SaveChanges();

                    client2.AccountBalance += 1000;
                    context2.SaveChanges();
                }
            }
        }
    }
}
