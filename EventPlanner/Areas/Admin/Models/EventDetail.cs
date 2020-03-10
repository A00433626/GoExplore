using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Areas.Admin.Models
{
    public class EventDetail
    {
        public int eventId { get; set; }
        public int categoryId { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public string venue { get; set; }
        public DateTime eventDate { get; set; }
        //public DateTime EventStartDate { get; set; }
        //public DateTime EventEndDate { get; set; }
        public int organizerId { get; set; }
        public Decimal ticketPrice { get; set; }
        public int totalSeats { get; set; }
        public string imagePath { get; set; }
    }
}