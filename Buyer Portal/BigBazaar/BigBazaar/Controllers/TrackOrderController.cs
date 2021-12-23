using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackOrder.Models;

namespace BigBazaar.Controllers
{
    public class TrackOrderController : Controller
    {
        // GET: TrackOrder
        // GET: TrackOrder
        public ActionResult TrackOrder()
        {
            string email = TempData["CustomerEmail"] as string;
            orderDetails obj = new orderDetails { sellerEmail = "", sellerName = "", orderID = "", customerEmail = "", customerName = "", productID = "", productName = "", productLink = "", productPrice = "", productDays = "", shipingAddress = "", totalPrice = 1 };
            return View();
        }

        
    }
}
 