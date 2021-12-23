using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Order.Models;

namespace BigBazaar.Controllers
{
    public class OrderController : Controller
    {
        orderDetails obj = new orderDetails { sellerEmail = "", productID = "", productName = "", productLink = "", productPrice = "", productDays = "", customerName = "", customerEmail = "", customerAddress = "", orderID = "" };

        // GET: Order
        public ActionResult Order(string productID)
        {
            ViewData["productID"] = productID;
            obj.readProduct(productID);
            ViewBag.sellerEmail = obj.sellerEmail;
            ViewBag.sellerName = obj.sellerName;
            ViewBag.sellerRating = obj.sellerRating;
            ViewBag.productName = obj.productName;
            ViewBag.productLink = obj.productLink;
            ViewBag.productPrice = obj.productPrice;
            ViewBag.productDays = obj.productDays;
            string CustomerID = TempData["CustomerEmail"] as string;
            TempData.Keep();
            obj.readCustomerDetail(CustomerID);
            ViewBag.customerName = obj.customerName;
            ViewBag.customerEmail = obj.customerAddress;
            ViewBag.customerAddress = obj.customerEmail;
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult Order(string productID,string shipadd, DateTime days1, DateTime days2)
        {
            int days = (int)days2.Day - (int)days1.Day; 
            ViewData["productID"] = productID;
            obj.readProduct(productID);
            string CustomerID = TempData["CustomerEmail"] as string;
            obj.readCustomerDetail(CustomerID);
            obj.calculatePrice(days, shipadd);
            ViewBag.totalPrice = obj.totalPrice - 60;
            ViewBag.totalShippingPrice = obj.totalPrice;
            ViewBag.shipadd = obj.shipingAddress;
            ViewBag.sellerEmail = obj.sellerEmail;
            ViewBag.sellerName = obj.sellerName;
            ViewBag.sellerRating = obj.sellerRating;
            ViewBag.productName = obj.productName;
            ViewBag.productLink = obj.productLink;
            ViewBag.productPrice = obj.productPrice;
            ViewBag.productDays = obj.productDays;
            ViewBag.customerName = obj.customerName;
            ViewBag.customerEmail = obj.customerAddress;
            ViewBag.customerAddress = obj.customerEmail;
            obj.storeData();
            

            return View();
        }


    }
}
