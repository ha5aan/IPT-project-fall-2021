using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Models;

namespace BigBazaar.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // Post: Register/Details/5
        public ActionResult Details(accountRegistration obj)
        {

            Console.WriteLine();
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username,string email, DateTime dob, string gender, string custadd, string psw) 
        {
            
            accountRegistration customer = new accountRegistration { name = username ,email = email , address = custadd, dob = dob, gender = gender, password = psw};
            customer.checkAccount();
            TempData["isAccountExist"] = customer.isAccountExist;
             if(customer.isAccountExist)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Signin");
            }
           
        }


    }
}
