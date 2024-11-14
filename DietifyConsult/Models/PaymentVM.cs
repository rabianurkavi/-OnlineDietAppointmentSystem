using Entities.Concrete;

namespace DietifyConsult.Models
{
    public class PaymentVM
    {
        public Consultant Consultants { get; set; }
        public int Quantity { get; set; }
    }
}
