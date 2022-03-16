using CRUD_ADO_NET.DAL;
using CRUD_ADO_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ADO_NET.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL _customerDAL;
        public CustomerController(CustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        // GET: Customer/Index
        public IActionResult Index()
        {

            var customers = _customerDAL.RetrieveCustomers(0); 
            return View(customers);
        }

        // GET: Customer/Edit/6
        public IActionResult Edit(int id)
        {
            var customers = _customerDAL.RetrieveCustomers(id);
            return View("Create", customers.Single());
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public IActionResult Create(Customer model)
        {
            ModelState.Remove("CustomerID");
            if (ModelState.IsValid)
            {
                _customerDAL.CreateCustomer(model);
                return RedirectToAction("Index");
            }

            return View("Create", model);
        }

        // POST: Customer/Update
        [HttpPost]
        public IActionResult Update(Customer model)
        {
            if (ModelState.IsValid)
            {
                _customerDAL.UpdateCustomer(model);
                return RedirectToAction("Index");
            }

            return View("Create", model);
        }

        // GET: Customer/Delete/2
        public IActionResult Delete(int id)
        {
            _customerDAL.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

    }
}
