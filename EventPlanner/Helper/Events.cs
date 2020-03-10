using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Helper
{
    public class Events
    {
        public int eventId { get; set; }
        public int categoryId { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public string venue { get; set; }
        public System.DateTime eventDate { get; set; }
        public int organizerId { get; set; }
        public decimal ticketPrice { get; set; }
        public int totalSeats { get; set; }
        public string imagePath { get; set; }
        public string City { get; set; }
    }
    public class EventListDetails 
    {
        public List<Events> Events { get; set; }
    }
}