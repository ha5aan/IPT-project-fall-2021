using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignIn.Models;

namespace BigBazaar.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string psw)
        {

            
            accountSignIn customer = new accountSignIn { email = email, password = psw, isLogin = false };
            customer.checkAccount();

            if (!customer.isLogin) {

                ViewBag.error = customer.isLogin;
                return View();
            }
            else
            {
                TempData["CustomerEmail"] = email;
                return RedirectToAction("ProductsPane", "ProductsPane");
            }

        }

    
    }
}
