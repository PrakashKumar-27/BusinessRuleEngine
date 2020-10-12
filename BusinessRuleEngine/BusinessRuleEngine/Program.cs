using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BusinessRuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerPayment customerPayment = new CustomerPayment() { CustomerId = 1, Amount = 10000 };
            PackingSlip packingSlip = new PackingSlip();
            //Payment for Product
            Payment productPayemt = new ProductPayment(customerPayment);
            Console.WriteLine("Start : Product Payment");
            packingSlip = productPayemt.ProcessPayment();
            var result = new JavaScriptSerializer().Serialize(packingSlip);
            Console.WriteLine("End : Product Payment " + result);

            //Payment for Book
            Payment bookPayment = new BookPayment(customerPayment);
            Console.WriteLine("Start : Book Payment");
            packingSlip = bookPayment.ProcessPayment();
            result = new JavaScriptSerializer().Serialize(packingSlip);
            Console.WriteLine("End : Book Payment" + result);

            //Payment for Active Membership
            Payment activateMembershipPayment = new MembershipPayment(customerPayment);
            Console.WriteLine("Start : Active Membership Payment");
            packingSlip = activateMembershipPayment.ProcessPayment();
            result = new JavaScriptSerializer().Serialize(packingSlip);
            Console.WriteLine("End : Active Membership Payment"+ result);


            //Payment for Upgrage Membership
            Payment upgradeMembershipPayment = new UpgradeMembershipPayment(customerPayment);
            Console.WriteLine("Start : Upgrage Membership Payment");
            packingSlip = upgradeMembershipPayment.ProcessPayment();
            result = new JavaScriptSerializer().Serialize(packingSlip);
            Console.WriteLine("End : Upgrage Membership Payment" + result);


            //Payment for Video
            Payment videoPayment = new VideoPayment(customerPayment);
            Console.WriteLine("Start : Video Payment");
            packingSlip = videoPayment.ProcessPayment();
            result = new JavaScriptSerializer().Serialize(packingSlip);
            Console.WriteLine("End : Video Payment"+ result);


            Console.ReadKey();
        }
    }
}
