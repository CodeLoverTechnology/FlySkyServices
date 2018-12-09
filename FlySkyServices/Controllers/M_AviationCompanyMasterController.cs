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
    public class M_AviationCompanyMasterController : Controller
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: M_AviationCompanyMaster
        public async Task<ActionResult> Index()
        {
            var m_AviationCompanyMaster = db.M_AviationCompanyMaster.Include(m => m.M_CityMaster);
            return View(await m_AviationCompanyMaster.ToListAsync());
        }

        // GET: M_AviationCompanyMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_AviationCompanyMaster m_AviationCompanyMaster = await db.M_AviationCompanyMaster.FindAsync(id);
            if (m_AviationCompanyMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_AviationCompanyMaster);
        }

        // GET: M_AviationCompanyMaster/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode");
            return View();
        }

        // POST: M_AviationCompanyMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompanyID,CompanyCode,CompanyName,CityID,ContactPerson,ContactNo,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_AviationCompanyMaster m_AviationCompanyMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_AviationCompanyMaster.Add(m_AviationCompanyMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode", m_AviationCompanyMaster.CityID);
            return View(m_AviationCompanyMaster);
        }

        // GET: M_AviationCompanyMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_AviationCompanyMaster m_AviationCompanyMaster = await db.M_AviationCompanyMaster.FindAsync(id);
            if (m_AviationCompanyMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode", m_AviationCompanyMaster.CityID);
            return View(m_AviationCompanyMaster);
        }

        // POST: M_AviationCompanyMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompanyID,CompanyCode,CompanyName,CityID,ContactPerson,ContactNo,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_AviationCompanyMaster m_AviationCompanyMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_AviationCompanyMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode", m_AviationCompanyMaster.CityID);
            return View(m_AviationCompanyMaster);
        }

        // GET: M_AviationCompanyMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_AviationCompanyMaster m_AviationCompanyMaster = await db.M_AviationCompanyMaster.FindAsync(id);
            if (m_AviationCompanyMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_AviationCompanyMaster);
        }

        // POST: M_AviationCompanyMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_AviationCompanyMaster m_AviationCompanyMaster = await db.M_AviationCompanyMaster.FindAsync(id);
            db.M_AviationCompanyMaster.Remove(m_AviationCompanyMaster);
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
