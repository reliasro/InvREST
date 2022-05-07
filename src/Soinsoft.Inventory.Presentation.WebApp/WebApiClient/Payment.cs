using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soinsoft.Inventory.Presentation.WebApp.WebApiClient
{
    public class Payment
    {
        public int Id { get; set; }
        public string CustomerNote { get; set; }
        public Decimal ValuePaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}