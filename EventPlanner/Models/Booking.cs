//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventPlanner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int bookingId { get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }
        public Nullable<int> seatsOccupied { get; set; }
        public Nullable<decimal> totalAmount { get; set; }
        public Nullable<System.DateTime> bookingDate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public string bookingStatus { get; set; }
        public string status { get; set; }
        public string phoneNumber { get; set; }
    
        public virtual Event_Details Event_Details { get; set; }
        public virtual User User { get; set; }
    }
}
