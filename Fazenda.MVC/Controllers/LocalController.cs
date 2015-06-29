using Fazenda.Aplicattion;
using Fazenda.Domain;
using Fazenda.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Fazenda.MVC.Controllers
{
    public class LocalController : Controller
    {
        private ILocalService service = new LocalService(new LocalRepository());
        private ICustomerService customerService = new CustomerService(new CustomerRepository());
        // GET: /Local/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        //
        // GET: /Local/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;
            Local local = service.Retrieve(i);

            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        //
        // GET: /Local/Create
        public ActionResult Create()
        {
            ViewData["CustomerId"] = GetCustomers();

            return View();
        }

        private SelectList GetCustomers()
        {
            var xpto = customerService.GetAll();
            return new SelectList(xpto, "Id", "Nome");
        }

        //
        // POST: /Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Entrada,Saida,Salario,CustomerId")] Local local)
        {
            if (ModelState.IsValid)
            {
                service.Create(local);
                return RedirectToAction("Index");
            }

            return View(local);
        }

        //
        // GET: /Local/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Local local = service.Retrieve(i);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["CustomerId"] = GetCustomers();
            return View(local);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Entrada,Saida,Salario,CustomerId")] Local local)
        {
            if (ModelState.IsValid)
            {
                service.Update(local);
                return RedirectToAction("Index");
            }
            return View(local);
        }

        //
        // GET: /Local/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Local local = service.Retrieve(i);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        //
        // POST: /Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
