using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeWebApplication.Models;

namespace PracticeWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDbContext employee;

        public HomeController(EmployeeDbContext employee)
        {
            this.employee = employee;
        }

        public async Task<IActionResult> Index()
        {
            var emp = await this.employee.Employees.ToListAsync();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeModel e)
        {
            if (ModelState.IsValid)
            {
                await employee.Employees.AddAsync(e);
                await employee.SaveChangesAsync();
                TempData["InsertSuccess"] = "Record inserted successfully.";
                return RedirectToAction("Index", "Home");
            }
            return View(e);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || employee.Employees == null)
            {
                return NotFound();
            }
            var empData = await employee.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || employee.Employees == null)
            {
                return NotFound();
            }
            var empData = await employee.Employees.FindAsync(id);
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EmployeeModel e)
        {
            if (id != e.Id)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                employee.Employees.Update(e);
                await employee.SaveChangesAsync();
                TempData["UpdateSuccess"] = "Record updated successfully.";
                return RedirectToAction("Index", "Home");
            }
            return View(e);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empData = await employee.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empData = await employee.Employees.FindAsync(id);
            if (empData == null)
            {
                return NotFound();
            }
            employee.Employees.Remove(empData);
            await employee.SaveChangesAsync();
            TempData["DeleteSuccess"] = "Record deleted successfully.";
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
