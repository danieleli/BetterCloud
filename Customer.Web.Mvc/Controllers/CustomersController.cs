using System.Linq;
using System.Net;
using System.Web.Mvc;
using Customer.Web.Mvc.Services;

namespace Customer.Web.Mvc.Controllers
{
    using Customer = Models.Customer;

    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_customerService.Customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _customerService.Customers.FirstOrDefault(c=>c.Id == id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address")] Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Save(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var customer = GetCustomerById(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        private Customer GetCustomerById(int id)
        {
            return _customerService.Customers.FirstOrDefault(c => c.Id == id);
        }

        // POST: Customers/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Save(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _customerService.Customers.FirstOrDefault(c => c.Id == id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete"),ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _customerService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _customerService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
