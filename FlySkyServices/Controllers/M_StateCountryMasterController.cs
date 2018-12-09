using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlySkyServices.Models;

namespace FlySkyServices.Controllers
{
    public class M_StateCountryMasterController : Controller
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: M_StateCountryMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_StateCountryMaster.ToListAsync());
        }

        // GET: M_StateCountryMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_StateCountryMaster m_StateCountryMaster = await db.M_StateCountryMaster.FindAsync(id);
            if (m_StateCountryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_StateCountryMaster);
        }

        // GET: M_StateCountryMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_StateCountryMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StateCountryID,StateCode,StateName,CountryCode,CountryName,Description,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_StateCountryMaster m_StateCountryMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_StateCountryMaster.Add(m_StateCountryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_StateCountryMaster);
        }

        // GET: M_StateCountryMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_StateCountryMaster m_StateCountryMaster = await db.M_StateCountryMaster.FindAsync(id);
            if (m_StateCountryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_StateCountryMaster);
        }

        // POST: M_StateCountryMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StateCountryID,StateCode,StateName,CountryCode,CountryName,Description,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_StateCountryMaster m_StateCountryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_StateCountryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_StateCountryMaster);
        }

        // GET: M_StateCountryMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_StateCountryMaster m_StateCountryMaster = await db.M_StateCountryMaster.FindAsync(id);
            if (m_StateCountryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_StateCountryMaster);
        }

        // POST: M_StateCountryMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_StateCountryMaster m_StateCountryMaster = await db.M_StateCountryMaster.FindAsync(id);
            db.M_StateCountryMaster.Remove(m_StateCountryMaster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
