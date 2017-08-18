using System;
using System.Linq;
using MVC.Models;

namespace MVC.Controllers
{
    public class AddUpdateController : Controller
    {
        private MVCContext context = new MVCContext();
        public ActionResult AddUpdate(Int32? id)
        {
            if (id == null)
            {
                ViewBag.TiTle = "Add";
                var customers = new Customer();
                return View("~/Views/Edit/Edit.cshtml", customers);
            }
            else
            {
                ViewBag.TiTle = "Update";
                Int64 customerID = Convert.ToInt64(id);
                var customers = context.Customers.Where(t => t.CustomerID == customerID).OrderBy(o => o.FirstName).ThenBy(p => p.LastName).SingleOrDefault();
                return View("~/Views/Edit/Edit.cshtml", customers);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer obj)
        {
            if (ModelState.IsValid)
            {
                if (Convert.ToInt64(obj.CustomerID) > 0)
                {
                    context.Customers.Attach(obj);
                    context.Configuration.ValidateOnSaveEnabled = false;

                    context.Entry(obj).Property(u => u.FirstName).IsModified = true;
                    context.Entry(obj).Property(u => u.LastName).IsModified = true;
                    context.Entry(obj).Property(u => u.BirthDate).IsModified = true;
                    context.Entry(obj).Property(u => u.Email).IsModified = true;
                    context.Entry(obj).Property(u => u.Address).IsModified = true;

                    if (context.SaveChanges() > 0)
                    {
                        context.Configuration.ValidateOnSaveEnabled = true;
                        TempData["Message"] = "Updated Successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error whle updating";
                    }
                }
                else
                {
                    context.Customers.Add(obj);
                    if (context.SaveChanges() > 0)
                    {
                        var customerID = obj.CustomerID;
                        TempData["Message"] = "Saved Successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error whle saving";
                    }
                }
                return RedirectToAction("List", "List");
            }

            return View("~/Views/Edit/Edit.cshtml", obj);
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
