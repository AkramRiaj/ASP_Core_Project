using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using ASP_Core_Project.Models;
using ASP_Core_Project.Data;

namespace ASP_Core_Project.Controllers
{
    public class EmploymentHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmploymentHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmploymentHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmploymentHistory.Include(e => e.Certificate).Include(e => e.Company).Include(e => e.Employee).Include(e => e.Institute);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmploymentHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentHistory = await _context.EmploymentHistory
                .Include(e => e.Certificate)
                .Include(e => e.Company)
                .Include(e => e.Employee)
                .Include(e => e.Institute)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employmentHistory == null)
            {
                return NotFound();
            }

            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Create
        public IActionResult Create()
        {
            ViewData["CertificateID"] = new SelectList(_context.Certificate, "CertificateID", "CertificateName");
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "Branch_Name");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName");
            ViewData["InstituteID"] = new SelectList(_context.Set<Institute>(), "InstituteID", "InstituteName");
            return View();
        }

        // POST: EmploymentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EmployeeID,CompanyId,CertificateID,InstituteID,JobStarttDate,JobEndDate")] EmploymentHistory employmentHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employmentHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificateID"] = new SelectList(_context.Certificate, "CertificateID", "CertificateName", employmentHistory.CertificateID);
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "Branch_Name", employmentHistory.CompanyId);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName", employmentHistory.EmployeeID);
            ViewData["InstituteID"] = new SelectList(_context.Set<Institute>(), "InstituteID", "InstituteName", employmentHistory.InstituteID);
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentHistory = await _context.EmploymentHistory.FindAsync(id);
            if (employmentHistory == null)
            {
                return NotFound();
            }
            ViewData["CertificateID"] = new SelectList(_context.Certificate, "CertificateID", "CertificateName", employmentHistory.CertificateID);
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "Branch_Name", employmentHistory.CompanyId);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName", employmentHistory.EmployeeID);
            ViewData["InstituteID"] = new SelectList(_context.Set<Institute>(), "InstituteID", "InstituteName", employmentHistory.InstituteID);
            return View(employmentHistory);
        }

        // POST: EmploymentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmployeeID,CompanyId,CertificateID,InstituteID,JobStarttDate,JobEndDate")] EmploymentHistory employmentHistory)
        {
            if (id != employmentHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employmentHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploymentHistoryExists(employmentHistory.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificateID"] = new SelectList(_context.Certificate, "CertificateID", "CertificateName", employmentHistory.CertificateID);
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "Branch_Name", employmentHistory.CompanyId);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName", employmentHistory.EmployeeID);
            ViewData["InstituteID"] = new SelectList(_context.Set<Institute>(), "InstituteID", "InstituteName", employmentHistory.InstituteID);
            return View(employmentHistory);
        }

        // GET: EmploymentHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentHistory = await _context.EmploymentHistory
                .Include(e => e.Certificate)
                .Include(e => e.Company)
                .Include(e => e.Employee)
                .Include(e => e.Institute)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employmentHistory == null)
            {
                return NotFound();
            }

            return View(employmentHistory);
        }

        // POST: EmploymentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employmentHistory = await _context.EmploymentHistory.FindAsync(id);
            _context.EmploymentHistory.Remove(employmentHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploymentHistoryExists(int id)
        {
            return _context.EmploymentHistory.Any(e => e.ID == id);
        }
    }
}
