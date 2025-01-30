using Microsoft.AspNetCore.Mvc;
using practice.Models;

namespace practice.Controllers
{
    public class EmployeeController : Controller
    {
        // Static list to store employee data (No database needed)
        private static List<Employee> employees = new List<Employee>();

        // GET: Employee/Create (Show the form)
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create (Handle form submission)
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employees.Add(employee); // Store in-memory
                return RedirectToAction("List"); // Redirect to the list view
            }
            return View();
        }

        // GET: Employee/List (Display entered employees)
        public ActionResult List()
        {
            return View(employees);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee updatedEmployee)
        {
            if (updatedEmployee == null)
            {
                return BadRequest();
            }

            var employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Sex = updatedEmployee.Sex;
                employee.Age = updatedEmployee.Age;
                employee.PhoneNo = updatedEmployee.PhoneNo;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();  // 404 if employee not found
            }
            return View(employee);  // Show a confirmation page before deletion
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);  // Remove from the list
            }
            return RedirectToAction("List"); // Redirect to employee list
        }



    }
}
