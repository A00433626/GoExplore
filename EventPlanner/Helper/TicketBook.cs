using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Helper
{
    public class TicketBook
    {
        public int EventId { get; set; }
        public int TotalSeats { get; set; }
        public decimal TotalAmount { get; set; }
    }
}