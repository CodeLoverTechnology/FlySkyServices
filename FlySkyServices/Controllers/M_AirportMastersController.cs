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
    public class M_AirportMastersController : Controller
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: M_AirportMasters
        public async Task<ActionResult> Index()
        {
            var m_AirportMasters = db.M_AirportMasters.Include(m => m.M_CityMaster);
            return View(await m_AirportMasters.ToListAsync());
        }

        // GET: M_AirportMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_AirportMasters m_AirportMasters = await db.M_AirportMasters.FindAsync(id);
            if (m_AirportMasters == null)
            {
                return HttpNotFound();
            }
            return View(m_AirportMasters);
        }

        // GET: M_AirportMasters/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode");
            return View();
        }

        // POST: M_AirportMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AirportID,AirportCode,AirportName,TerminalCount,CityID,CreatedBy,CreatedDate,ModifiedBy,Active")] M_AirportMasters m_AirportMasters)
        {
            if (ModelState.IsValid)
            {
                db.M_AirportMasters.Add(m_AirportMasters);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode", m_AirportMasters.CityID);
            return View(m_AirportMasters);
        }

        // GET: M_AirportMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_AirportMasters m_AirportMasters = await db.M_AirportMasters.FindAsync(id);
            if (m_AirportMasters == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode", m_AirportMasters.CityID);
            return View(m_AirportMasters);
        }

        // POST: M_AirportMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AirportID,AirportCode,AirportName,TerminalCount,CityID,CreatedBy,CreatedDate,ModifiedBy,Active")] M_AirportMasters m_AirportMasters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_AirportMasters).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.M_CityMaster, "CityID", "CityCode", m_AirportMasters.CityID);
            return View(m_AirportMasters);
        }

        // GET: M_AirportMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_AirportMasters m_AirportMasters = await db.M_AirportMasters.FindAsync(id);
            if (m_AirportMasters == null)
            {
                return HttpNotFound();
            }
            return View(m_AirportMasters);
        }

        // POST: M_AirportMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_AirportMasters m_AirportMasters = await db.M_AirportMasters.FindAsync(id);
            db.M_AirportMasters.Remove(m_AirportMasters);
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
