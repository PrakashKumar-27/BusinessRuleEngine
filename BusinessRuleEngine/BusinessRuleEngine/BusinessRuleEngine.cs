using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine
{
    public class PackingSlip
    {
        public int PaymentSlipId { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
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

        public abstract void ProcessPayment();
    }

    public class BookPayment : Payment
    {
        public BookPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override void ProcessPayment()
        {
            PackingSlip packingSlip = new PackingSlip();
            packingSlip.Amount = CustomerPayment.Amount;
            packingSlip.CustomerId = CustomerPayment.CustomerId;

            //packingSlip
        }
    }

    public class ProductPayment : Payment
    {
        public ProductPayment(CustomerPayment customerPayment)
        : base(customerPayment)
        {
        }
        public override void ProcessPayment()
        {
        }
    }
}
