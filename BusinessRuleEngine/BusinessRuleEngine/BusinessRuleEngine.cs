using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine
{
    public enum PaymentFor { Shipping, RoyaltyDepartment, ActivateMembership, UpgrageMembership, Video };
    public class PackingSlip
    {
        public int PaymentSlipId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public double AgentCommisionAmount { get; set; }
        public string EmailSentFor { get; set; }
        public PaymentFor paymentFor { get; set; }
        public bool FreeAidVideo { get; set; } = false;
    }

    public class CustomerPayment
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
    public abstract class Payment
    {
        protected CustomerPayment CustomerPayment { get; private set; }
        public Payment(CustomerPayment customerPayment)
        {
            CustomerPayment = customerPayment;
        }

        public PackingSlip GetPackingSlip(PaymentFor paymentFor)
        {
            PackingSlip packingSlip = new PackingSlip();
            packingSlip.PaymentSlipId = 1;
            packingSlip.Amount = CustomerPayment.Amount;
            packingSlip.CustomerId = CustomerPayment.CustomerId;
            packingSlip.paymentFor = paymentFor;
            return packingSlip;
        }

        public string SendEmail(int emailFor =1)
        {
            return emailFor == 1 ? "Activation Membership Email" : "Upgrage Membership Email";
        }

        public double GetAgentCommisionAmount()
        {
            return CustomerPayment.Amount * 2 / 100;
        }
        public abstract PackingSlip ProcessPayment();
    }

    public class BookPayment : Payment
    {
        public BookPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override PackingSlip ProcessPayment()
        {
            PackingSlip packingSlip=  base.GetPackingSlip(PaymentFor.Shipping);
            packingSlip.AgentCommisionAmount = base.GetAgentCommisionAmount();
            return packingSlip;
        }
    }

    public class ProductPayment : Payment
    {
        public ProductPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override PackingSlip ProcessPayment()
        {
            PackingSlip packingSlip = base.GetPackingSlip(PaymentFor.RoyaltyDepartment);
            packingSlip.PaymentSlipId = 00000; //Generating duplicate Id
            packingSlip.AgentCommisionAmount = base.GetAgentCommisionAmount();
            return packingSlip;
        }
    }

    public class MembershipPayment : Payment
    {
        public MembershipPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override PackingSlip ProcessPayment()
        {
            PackingSlip packingSlip = base.GetPackingSlip(PaymentFor.ActivateMembership);
            packingSlip.EmailSentFor = base.SendEmail(1);
            return packingSlip;
        }
    }

    public class UpgradeMembershipPayment : Payment
    {
        public UpgradeMembershipPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override PackingSlip ProcessPayment()
        {
            PackingSlip packingSlip = base.GetPackingSlip(PaymentFor.UpgrageMembership);
            packingSlip.EmailSentFor = base.SendEmail(2);
            return packingSlip;
        }
    }

    public class VideoPayment : Payment
    {
        public VideoPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override PackingSlip ProcessPayment()
        {
            PackingSlip packingSlip = base.GetPackingSlip(PaymentFor.UpgrageMembership);
            packingSlip.FreeAidVideo = true;
            return packingSlip;
        }
    }
}
