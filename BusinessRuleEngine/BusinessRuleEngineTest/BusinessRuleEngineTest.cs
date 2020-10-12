using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRuleEngine;

namespace BusinessRuleEngineTest
{
    [TestClass]
    public class BusinessRuleEngineTest
    {
        [TestMethod]
        public void BookPaymentTest()
        {
            CustomerPayment customerPayment = new CustomerPayment();
            Payment bookPayment = new BookPayment(customerPayment);
            bookPayment.ProcessPayment();
        }
    }
}
