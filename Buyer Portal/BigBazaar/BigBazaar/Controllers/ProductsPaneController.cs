using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsPane.Models;

namespace BigBazaar.Controllers
{
    public class ProductsPaneController : Controller
    {
        // GET: ProductsPane
        public ActionResult ProductsPane()
        {
            Products obj = new Products();
            obj.readProduct();
            ViewBag.productlist = obj.product;
            return View();
        }


        // GET: ProductsPane/Details/5
        /* public ActionResult Details(int id)
         {
             return View();
         }

         // GET: ProductsPane/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: ProductsPane/Create
         [HttpPost]
         public ActionResult Create(FormCollection collection)
         {
             try
             {
                 // TODO: Add insert logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }

         // GET: ProductsPane/Edit/5
         public ActionResult Edit(int id)
         {
             return View();
         }

         // POST: ProductsPane/Edit/5
         [HttpPost]
         public ActionResult Edit(int id, FormCollection collection)
         {
             try
             {
                 // TODO: Add update logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }

         // GET: ProductsPane/Delete/5
         public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: ProductsPane/Delete/5
         [HttpPost]
         public ActionResult Delete(int id, FormCollection collection)
         {
             try
             {
                 // TODO: Add delete logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }*/

    }
}