using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BaseJumpContracts.DAL;
using BaseJumpContracts.Models;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System;

namespace BaseJumpContracts.Controllers
{
    public class CustomerController : Controller
    {
        private ContractContext db = new ContractContext();

        // GET: Customer
        public ActionResult Index()
        {
            //TODO: Factor all this out into a public function that all controllers can use
            int counter = 0;
            string checker =  "BJC" + counter.ToString() + "timeStamp";
            while (Request.Cookies[checker] != null)
            {
                var ID = counter;

                var timeStampKey = "BJC" + counter.ToString() + "timeStamp";
                var timeStamp = Request.Cookies[timeStampKey].Value;

                System.Diagnostics.Debug.WriteLine(timeStamp);

                //Event type

                //Class

                //Write all this shit to the database

                counter++;
                checker =  "BJC" + counter.ToString() + "timeStamp";
            }

            Request.Cookies.Clear();

            return View(db.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
                
            return View(customer);
        }

        // GET: Customer/Contract/5
        public FileResult Contract(int? id)
        {
            //Find customer
            Customer customer = db.Customers.Find(id);
            //Extract subscriptions
            var subscriptions = customer.Subscriptions;
            //Caculate total price
            List<decimal> prices = new List<decimal>();
            foreach (var subscription in subscriptions) {
                prices.Add(subscription.Price);
            }
            var totalPrice = prices.Sum();

            //Initialize
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();

            //Define fonts
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            //Build document
            document.Add(new Paragraph(customer.Name, titleFont));

            var subscriptionsTable = new PdfPTable(4);

            //Format table
            subscriptionsTable.HorizontalAlignment = 0;
            subscriptionsTable.SpacingBefore = 10;
            subscriptionsTable.SpacingAfter = 10;
            subscriptionsTable.DefaultCell.Border = 1;
            subscriptionsTable.DefaultCell.Padding = 10;

            //Table Header
            subscriptionsTable.AddCell("Service ID");
            subscriptionsTable.AddCell("Name");
            subscriptionsTable.AddCell("Price");
            subscriptionsTable.AddCell("Term");

            //Build table values
            foreach(var subscription in subscriptions)
            {
                var service = subscription.Service;
                subscriptionsTable.AddCell(new Phrase(service.ID.ToString()));
                subscriptionsTable.AddCell(new Phrase(service.Name));
                subscriptionsTable.AddCell(new Phrase(subscription.Price.ToString()));
                subscriptionsTable.AddCell(new Phrase(subscription.Term.ToString()));
            }

            document.Add(subscriptionsTable);

            document.Add(new Paragraph(string.Format("Total Monthly Recurring Charges: ${0}", totalPrice), bodyFont));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph("Sign:__________________________________________"));
            document.Add(new Paragraph("Print Name:____________________________________"));
            document.Add(new Paragraph("Date:__________________________________________"));

            //Close stream and cast to byte array
            document.Close();
            byte[] content = output.ToArray();

            return File(content, "application/pdf", string.Format("{0}.pdf", customer.Name));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
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
