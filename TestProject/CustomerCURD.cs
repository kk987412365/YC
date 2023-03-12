using NUnit.Framework;
using YC.Models;
using System;
using YC.Attributes;
using YC.Utilities;
using YC.Enums;
using YC.Extension;
namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CustomerVerifySuccess()
        {
            var TestItems = new Customer() { Id = "A123456789", Name = "Mark", Age = 25, Email = "Mark@gmail.com" };
            var result = TestItems.Verify();
            var expected = "success";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CustomerVerifyFail()
        {
            var TestItems = new Customer()
            {
                Id = "A1234567891",
                Name = "Markkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk",
                Age = 25,
                Email = ""
            };
            var result = TestItems.Verify();
            var expected = " Id:長度過長|| Name:長度過長|| Email:無值||";
            Assert.AreEqual(expected, result);

            TestItems = new Customer()
            {
                Id = "",
                Name = "",
                Age = 25,
                Email = ""
            };
            result = TestItems.Verify();
            expected = " Id:無值|| Name:無值|| Email:無值||";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CustomerInsert()
        {
            
            var expected = "success";
            var TestItems = new Customer() { Id = "A000000000", Name = "Mark", Age = 25, Email = "Mark@gmail.com" };

            ResetTestData(TestItems.Id);
            var result = Customer.InsertFunc(TestItems);
            Assert.AreEqual(expected, result);
            ResetTestData(TestItems.Id);
        }
        [Test]
        public void DeleteTest()
        {
            var result = "";
            var expected = "success";
            var TestItems = new Customer() { Id = "A000000000", Name = "Mark", Age = 25, Email = "Mark@gmail.com" };

            ResetTestData(TestItems.Id);
            Customer.InsertFunc(TestItems);
            result = Customer.DeleteCustomerByID("A000000000");
            Assert.AreEqual(expected, result);
            ResetTestData(TestItems.Id);
        }
        [Test]
        public void UpdateTest()
        {
            var result = "";
            var expected = "success";
            var TestItems = new Customer() { Id = "A000000000", Name = "Mark", Age = 25, Email = "Mark@gmail.com" };

            ResetTestData(TestItems.Id);
            Customer.InsertFunc(TestItems);
            TestItems.Name = "Peter";
            result = Customer.UpdateFunc(TestItems);
            Assert.AreEqual(expected, result);
            ResetTestData(TestItems.Id);
        }
        [Test]
        public void InsertUpdateDeleteSuccess()
        {            
            var expected = "success";
            var TestItems = new Customer() { Id = "A000000000", Name = "Mark", Age = 25, Email = "Mark@gmail.com" };

            ResetTestData(TestItems.Id);
            var result = Customer.InsertFunc(TestItems);
            TestItems.Name = "Peter";
            result = Customer.UpdateFunc(TestItems);
            Assert.AreEqual(expected, result);
            Customer.DeleteCustomerByID("A000000000");
        }

        public string ResetTestData(string id)
        {
            return Customer.DeleteCustomerByID(id);
        }
    }
}