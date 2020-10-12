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
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, AgentCommisionAmount=200, paymentFor = PaymentFor.Shipping };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1 , Amount = 10000 };
            Payment bookPayment = new BookPayment(customerPayment);
            var result =  bookPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.AgentCommisionAmount, result.AgentCommisionAmount);
        }

        [TestMethod]
        public void ProductPaymentTest()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, AgentCommisionAmount = 200, EmailSentFor = "Activation Membership Email", FreeAidVideo = false, paymentFor = PaymentFor.RoyaltyDepartment };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment bookPayment = new BookPayment(customerPayment);
            var result = bookPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.AgentCommisionAmount, result.AgentCommisionAmount);
        }
    }
}
