using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using ASP_Core_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ASP_Core_Project.Data;

namespace ASP_Core_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly    ApplicationDbContext _context;

        private IHostingEnvironment _env;

        public EmployeesController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var employee = from s in _context.Employee.Include(e => e.Department).Include(e => e.Job) select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(a => a.FullName.StartsWith(searchString)
                                       || a.Address.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employee = employee.OrderBy(s => s.FullName);
                    break;
                case "date_desc":
                    employee = employee.OrderByDescending(s => s.Address);
                    break;
                default:
                    employee = employee.OrderBy(s => s.Department.DepartmentName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Employee>.CreateAsync(employee.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "DepartmentID", "DepartmentName");
            ViewData["JobID"] = new SelectList(_context.Set<Job>(), "JobID", "JobTitle");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,Lastname,Address,Contact,DepartmentID,JobID,ImageFile")] Employee employee, IFormFile uploaded_Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imagePathToFolder = _env.WebRootPath + "\\Employees\\" + uploaded_Image.FileName;
                    using (var stream = new FileStream(imagePathToFolder, FileMode.Create))
                    {
                        uploaded_Image.CopyTo(stream);
                    }

                    employee.ImageFile = "~/Employees/" + uploaded_Image.FileName;
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View();
                }

            }
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "DepartmentID", "DepartmentName", employee.DepartmentID);
            ViewData["JobID"] = new SelectList(_context.Set<Job>(), "JobID", "JobTitle", employee.JobID);
            return View(employee);
        }



        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "DepartmentID", "DepartmentName", employee.DepartmentID);
            ViewData["JobID"] = new SelectList(_context.Set<Job>(), "JobID", "JobTitle", employee.JobID);
            return View(employee);
        }

        // POST: Employees/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,FirstName,Lastname,Address,Contact,DepartmentID,JobID,ImageFile")] Employee employee, IFormFile uploaded_Image)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }
            try
            {
                if (uploaded_Image != null)
                {
                    string imagePath = _env.WebRootPath + "\\Employees\\" + uploaded_Image.FileName;
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        uploaded_Image.CopyTo(stream);
                    }

                    employee.ImageFile = "~/Employees/" + uploaded_Image.FileName;
                }

                _context.Update(employee);
                await _context.SaveChangesAsync();
                ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "DepartmentID", "DepartmentName", employee.DepartmentID);
                ViewData["JobID"] = new SelectList(_context.Set<Job>(), "JobID", "JobTitle", employee.JobID);

                return RedirectToAction("Index", "Employees");
            }
            catch (Exception ex)
            {
                return View();
            }           

        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}
