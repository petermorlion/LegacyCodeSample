using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LegacyCodeSample;
using TypeMock.ArrangeActAssert.Suggest;
using TypeMock.ArrangeActAssert;
using System.Linq;

//-------------------------------------------------------------------------------------------------------------------
// Unit Tests suggested by Typemock.
// You are invited to modify the tests just take note to leave tests in region
//-------------------------------------------------------------------------------------------------------------------
namespace UnitTestsLegacyCodeSample
{
    [SafetyNet(typeof(LegacyCodeSample.DiscountCalculator))]
    [Isolated()]
    [TestClass()]
    public class DiscountCalculatorTests
    {
        [TestMethod]
        public void CalculateDiscount_OnBirthday_Returns40()
        {
            // arrange
            var discountCalculator = new DiscountCalculator();
            var customer = new Customer();
            customer.Birthdate = DateTime.UtcNow;

            // act
            var result = discountCalculator.CalculateDiscount(customer);

            // assert
            Assert.AreEqual(40.0, result, 0.01);
        }

        [TestMethod]
        public void CalculateDiscount_ForGoldMemberOnBirthday_Returns40()
        {
            // arrange
            var discountCalculator = new DiscountCalculator();
            var customer = new Customer();
            customer.Birthdate = DateTime.UtcNow;
            customer.IsGoldMember = true;
            Isolate.WhenCalled(() => customer.IsEmployee()).WillReturn(false);

            // act
            var result = discountCalculator.CalculateDiscount(customer);

            // assert
            Assert.AreEqual(40.0, result, 0.01);
        }

        [TestMethod]
        public void CalculateDiscount_ForGoldMemberEmployeeOlderThan40_Returns20()
        {
            // arrange
            var discountCalculator = new DiscountCalculator();
            var customer = new Customer();
            customer.Birthdate = DateTime.UtcNow.AddYears(-50);
            customer.IsGoldMember = true;
            Isolate.WhenCalled(() => customer.IsEmployee()).WillReturn(true);

            // act
            var result = discountCalculator.CalculateDiscount(customer);

            // assert
            Assert.AreEqual(20.0, result, 0.01);
        }

        #region Unit Tests for CalculateDiscount

        [TestMethod]
        public void CalculateDiscount_Test_Returns00()
        {
            // arrange
            var discountCalculator = new DiscountCalculator();
            var customer = new Customer();
             
            // act
            var result = discountCalculator.CalculateDiscount(customer);
             
            // assert
            Assert.AreEqual(0.0, result, 0.01);
        }

        
        [TestMethod]
        public void CalculateDiscount_Test_Returns300()
        {
            // arrange
            var discountCalculator = new DiscountCalculator();
            var customer = new Customer();
            customer.IsGoldMember = true;
            Isolate.WhenCalled(() => customer.IsEmployee()).WillReturn(false);
             
            // act
            var result = discountCalculator.CalculateDiscount(customer);
             
            // assert
            Assert.AreEqual(30.0, result, 0.01);
        }

        
        [TestMethod]
        public void CalculateDiscount_Test_Returns150()
        {
            // arrange
            var discountCalculator = new DiscountCalculator();
            var customer = new Customer();
            customer.IsGoldMember = true;
            var dateTime = DateTime.MaxValue;
            customer.Birthdate = dateTime;
            Isolate.WhenCalled(() => customer.IsEmployee()).WillReturn(true);
             
            // act
            var result = discountCalculator.CalculateDiscount(customer);
             
            // assert
            Assert.AreEqual(15.0, result, 0.01);
        }

        #endregion

        #region Setup
        [TestInitialize]
        public void Setup_RunBeforeEachTest()
        {
            TestUtil.ResetAllStatics();
            TestUtil.AssertRunningInSandbox();
        }
        #endregion

    }
}