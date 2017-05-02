using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseJumpContracts.DAL;
using BaseJumpContracts.Models;

namespace BaseJumpContracts.Controllers
{
    public class SubscriptionController : Controller
    {
        private ContractContext db = new ContractContext();

        // GET: Subscription/Create
        public ActionResult Create(int customerID)
        {
            ViewBag.CustomerID = customerID;
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Name");
            return View();
        }

        // POST: Subscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubscriptionID,CustomerID,ServiceID,Price,Term")] Subscription subscription)
        {
            var customerID = subscription.CustomerID;
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Details", "Customer", new { ID = customerID });
            }

            ViewBag.CustomerID = customerID;
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Name", subscription.ServiceID);
            return View(subscription);
        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            db.Subscriptions.Remove(subscription);
            db.SaveChanges();
            return RedirectToAction("Details", "Customer", new { id = subscription.CustomerID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
