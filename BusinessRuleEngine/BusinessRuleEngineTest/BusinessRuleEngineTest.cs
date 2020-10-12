using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRuleEngine;

namespace BusinessRuleEngineTest
{
    [TestClass]
    public class BusinessRuleEngineTest
    {
        [TestMethod]
        public void BookPaymentTest_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, AgentCommisionAmount=200, paymentFor = PaymentFor.Shipping };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1 , Amount = 10000 };
            Payment bookPayment = new BookPayment(customerPayment);
            var result =  bookPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.AgentCommisionAmount, result.AgentCommisionAmount);
        }

        [TestMethod]
        public void BookPaymentTest_Not_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000,  paymentFor = PaymentFor.Shipping };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment bookPayment = new BookPayment(customerPayment);
            var result = bookPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreNotEqual(packingSlip.AgentCommisionAmount, result.AgentCommisionAmount);
        }

        [TestMethod]
        public void ProductPaymentTest_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, AgentCommisionAmount = 200, paymentFor = PaymentFor.RoyaltyDepartment };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment productPayment = new ProductPayment(customerPayment);
            var result = productPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.AgentCommisionAmount, result.AgentCommisionAmount);
        }

        [TestMethod]
        public void ProductPaymentTest_Not_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, AgentCommisionAmount = 0, paymentFor = PaymentFor.RoyaltyDepartment };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment productPayment = new ProductPayment(customerPayment);
            var result = productPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreNotEqual(packingSlip.AgentCommisionAmount, result.AgentCommisionAmount);
        }

        [TestMethod]
        public void ActivateMembershipPaymentTest_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, EmailSentFor = "Activation Membership Email", paymentFor = PaymentFor.ActivateMembership };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment activateMembershipPayment = new MembershipPayment(customerPayment);
            var result = activateMembershipPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.EmailSentFor, result.EmailSentFor);
        }

        [TestMethod]
        public void ActivateMembershipPaymentTest_Not_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, EmailSentFor = "Upgrage Membership Email", paymentFor = PaymentFor.ActivateMembership };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment activateMembershipPayment = new MembershipPayment(customerPayment);
            var result = activateMembershipPayment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreNotEqual(packingSlip.EmailSentFor, result.EmailSentFor);
        }

        [TestMethod]
        public void UpgradeMembershipPaymentTest_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, EmailSentFor = "Upgrage Membership Email", paymentFor = PaymentFor.UpgrageMembership };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment payment = new UpgradeMembershipPayment(customerPayment);
            var result = payment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.EmailSentFor, result.EmailSentFor);
        }

        [TestMethod]
        public void UpgradeMembershipPaymentTest_Not_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, EmailSentFor = "Activate Membership Email", paymentFor = PaymentFor.UpgrageMembership };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment payment = new UpgradeMembershipPayment(customerPayment);
            var result = payment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreNotEqual(packingSlip.EmailSentFor, result.EmailSentFor);
        }

        [TestMethod]
        public void VideoPaymentTest_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, FreeAidVideo = true, paymentFor = PaymentFor.Video };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment payment = new VideoPayment(customerPayment);
            var result = payment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreEqual(packingSlip.FreeAidVideo, result.FreeAidVideo);
        }


        [TestMethod]
        public void VideoPaymentTest_Not_OK()
        {
            PackingSlip packingSlip = new PackingSlip() { CustomerId = 1, PaymentSlipId = 1, Amount = 10000, FreeAidVideo = true, paymentFor = PaymentFor.Video };
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            Payment payment = new VideoPayment(customerPayment);
            var result = payment.ProcessPayment();
            Assert.AreEqual(packingSlip.paymentFor, result.paymentFor);
            Assert.AreNotEqual(false, result.FreeAidVideo);
        }
    }
}
