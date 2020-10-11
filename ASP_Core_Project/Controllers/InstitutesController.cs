using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Core_Project.Models;
using ASP_Core_Project.Data;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace ASP_Core_Project.Controllers
{
    public class InstitutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Institutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institute.ToListAsync());
        }



        public IActionResult DataInsert()
        {
            return View();
        }



        [HttpPost]

        public JsonResult DataInsert(string instituteJason)
        {
            var js = new JsonSerializer();

            Institute[] institute = (Institute[])Newtonsoft.Json.JsonConvert.DeserializeObject(instituteJason, typeof(Institute[]));

           try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(var i in institute)
                        {
                            i.InstituteID = 0;
                            _context.Institute.Add(i);
                            _context.SaveChanges();
                        }
                        
                        dbContextTransaction.Commit();
                        return Json("Data are inserted in Institute Table");
                    }
                    catch (Exception ex)
                    {
                        string kkk = ex.Message;
                        dbContextTransaction.Rollback();
                        return Json("There is a Probem arise");
                    }


                   

                }

            }
            catch(Exception ex)
            {
                string kkk = ex.Message;
            }

            return Json("There is a Probem arise");

            // return Json("skks",);
        }





        // GET: Institutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institute = await _context.Institute
                .FirstOrDefaultAsync(m => m.InstituteID == id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // GET: Institutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstituteID,InstituteName,Address,City")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institute);
        }

        // GET: Institutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institute = await _context.Institute.FindAsync(id);
            if (institute == null)
            {
                return NotFound();
            }
            return View(institute);
        }

        // POST: Institutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstituteID,InstituteName,Address,City")] Institute institute)
        {
            if (id != institute.InstituteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituteExists(institute.InstituteID))
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
            return View(institute);
        }

        // GET: Institutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institute = await _context.Institute
                .FirstOrDefaultAsync(m => m.InstituteID == id);
            if (institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // POST: Institutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institute = await _context.Institute.FindAsync(id);
            _context.Institute.Remove(institute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituteExists(int id)
        {
            return _context.Institute.Any(e => e.InstituteID == id);
        }
    }
}
