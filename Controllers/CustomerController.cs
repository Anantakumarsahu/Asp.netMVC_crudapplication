using MvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index()
        {
            using(DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.ToList());
            }
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Customers.Add(customer);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModel = new DbModels())
                {
                    Customer customer = dbModel.Customers.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Customers.Remove(customer);
                    dbModel.SaveChanges();
                }

           
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
