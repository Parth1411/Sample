using System;
using System.Linq;
using System.Net;
using MVC.Models;

namespace MVC.Controllers
{
    public class ListController : Controller
    {
        private MVCContext context = new MVCContext();
        public ActionResult List()
        {   
            var customers = context.Customers.OrderBy(o => o.FirstName).ThenBy(p => p.LastName).ToList();
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
            
        public ActionResult Delete(Int64? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Int64 customerID = Convert.ToInt64(id);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID).SingleOrDefault();
            if (customers == null)
            {
                return HttpNotFound();
            }
            context.Customers.Remove(customers);
            if (context.SaveChanges() > 0)
            {
                TempData["Message"] = "Deleted Successfully";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Message"] = "Error while deleting";
                return HttpNotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
