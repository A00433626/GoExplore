using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Helper;
using EventPlanner.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace EventPlanner.Controllers
{
    public class PaymentsController : Controller
    {
        private GoExploreEntities db = new GoExploreEntities();

        // GET: Payments
        public ActionResult Index(string v,string s) 
        {
            if (Session["UserId"] == null)
            {
                Session["v"] = v;
                Session["s"] = s;
                return RedirectToAction("Index", "User");
            }
            PaymentModel paymentModel = new PaymentModel();
            if (s == "T")
            {
                v = Utility.Decrypt(v, "GoExploreHashKey");
                TicketBook ticket = JsonConvert.DeserializeObject<TicketBook>(v, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                paymentModel.Amount = ticket.TotalAmount;
                paymentModel.TotalAmount = ticket.TotalAmount;
                paymentModel.SeatsOccupied = ticket.TotalSeats;
                paymentModel.EventId = ticket.EventId;
                ViewBag.BookingId = 0;
            }
            else if (s == "F")
            {
                v = Utility.Decrypt(v, "GoExploreHashKey");
                paymentModel = JsonConvert.DeserializeObject<PaymentModel>(v, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                ViewBag.BookingId = 0;
            }
            else 
            {
                ViewBag.Message = "Success";
                ViewBag.BookingId = paymentModel.BookingId;
                paymentModel = null;
            }
            ViewBag.countryId = db.Countries;
            ViewBag.stateId = db.States;

            return View(paymentModel);
        }
        [HttpPost]
        public ActionResult BookEvent(int eventId, int totalSeats, decimal totalAmount)
        {
            TicketBook ticket = new TicketBook();
            ticket.EventId = eventId;
            ticket.TotalAmount = totalAmount;
            ticket.TotalSeats = totalSeats;
            string json = JsonConvert.SerializeObject(ticket);
            var encryptedData = Utility.Encrypt(json, "GoExploreHashKey");
            return RedirectToAction("Index", "Payments", new {v= encryptedData,s="T" });
        }
        [HttpPost]
        public ActionResult Index(PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                var bookingId = 0;
                using (var context = new GoExploreEntities()) //need to maintain transaction here
                {
                    Booking booking = new Booking();
                    booking.bookingDate = DateTime.Now;
                    booking.eventId = paymentModel.EventId;
                    booking.address = paymentModel.Address;
                    booking.bookingStatus = "S";
                    booking.city = paymentModel.City;
                    booking.country = paymentModel.Country;
                    booking.seatsOccupied = paymentModel.SeatsOccupied;
                    booking.state = paymentModel.State;
                    booking.status = "S";
                    booking.totalAmount = paymentModel.TotalAmount;
                    booking.userId = Convert.ToInt32(Session["UserId"]);
                    booking.zipCode = paymentModel.ZipCode;
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                    Payment payment = new Payment();
                    payment.bookingId = booking.bookingId;
                    payment.amount = paymentModel.TotalAmount;
                    payment.cardNumer = paymentModel.CardNumber;
                    payment.cardType = paymentModel.CardType;
                    payment.cvv = paymentModel.CVV;
                    payment.expiryDate = paymentModel.ExpiryMonth + "/" + paymentModel.ExpiryYear.ToString();
                    payment.firstName = paymentModel.NameOnCard;
                    payment.lastName = "";
                    payment.paymentMode = paymentModel.CardType;
                    payment.status = "S";
                    db.Payments.Add(payment);
                    db.SaveChanges();
                    bookingId = booking.bookingId;
                }
                ViewBag.result = "Success";
                ViewBag.bookingId = bookingId;
                return View() ;
            }
            else
            {
                //string json = JsonConvert.SerializeObject(paymentModel);
                //var encryptedData = Utility.Encrypt(json, "GoExploreHashKey");
                paymentModel.Amount = paymentModel.TotalAmount;
                ViewBag.BookingId = 0;
                return View(paymentModel);
            }
        }
    }
}
