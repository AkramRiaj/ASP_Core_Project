using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_Project.Data;
using Microsoft.AspNetCore.Mvc;
using ASP_Core_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ASP_Core_Project.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
       // GET: Details
        public IActionResult Index(string searchString, int? DepartmentID, int? EmployeeID)
        {
            var singleSelectList = new SelectedDetailsModel();

            singleSelectList.Department = _context.Department.ToList();


            if (DepartmentID == null)
            {
                byte[] kkk = HttpContext.Session.Get("DepartmentID");

                if (kkk != null)
                {
                    string someString = Encoding.ASCII.GetString(kkk);
                    DepartmentID = Convert.ToInt32(someString);
                }
            }

            if (DepartmentID != null)
            {

                HttpContext.Session.SetString("DepartmentID", DepartmentID.ToString());
                singleSelectList.Employee = _context.Employee.Include(i => i.Job).Where(w => w.DepartmentID == DepartmentID.Value).ToList();


            }

            if (EmployeeID != null)
            {

                singleSelectList.EmploymentHistory = _context.EmploymentHistory.Include(e => e.Institute).Include(e => e.Company).Include(w => w.Certificate).Where(w => w.EmployeeID == EmployeeID.Value).ToList();

            }

            return View(singleSelectList);

            
        }
    }
}