using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Customer.Web.Mvc.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Customer.Web.Mvc._Tests.Models
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void InstantiateDb()
        {
            // act
            var db = new CustomerDb();

            // assert
            Assert.That(db, Is.Not.Null, "db is null");
        }

        [Test]
        public void FirstCustomer_Exists()
        {
            // arrange
            var db = new CustomerDb();

            // act
            var firstCustomer = db.Customers.First();

            // assert
            Assert.That(firstCustomer, Is.Not.Null, "firstCustomer is null");

            // affirm
            var json = JsonConvert.SerializeObject(firstCustomer);
            Console.WriteLine(json);
        }

        [Test]
        public void CustomerCount_GT_2()
        {
            // arrange
            var db = new CustomerDb();

            // act
            var count = db.Customers.Count();

            // assert
            Assert.That(count, Is.GreaterThan(2));
        }
    }
}
