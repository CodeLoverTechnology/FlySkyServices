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
    public class M_CityMasterController : Controller
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: M_CityMaster
        public async Task<ActionResult> Index()
        {
            var m_CityMaster = db.M_CityMaster.Include(m => m.M_StateCountryMaster);
            return View(await m_CityMaster.ToListAsync());
        }

        // GET: M_CityMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_CityMaster m_CityMaster = await db.M_CityMaster.FindAsync(id);
            if (m_CityMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_CityMaster);
        }

        // GET: M_CityMaster/Create
        public ActionResult Create()
        {
            ViewBag.StateCountryID = new SelectList(db.M_StateCountryMaster, "StateCountryID", "StateCode");
            return View();
        }

        // POST: M_CityMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CityID,CityCode,CityName,StateCountryID,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_CityMaster m_CityMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_CityMaster.Add(m_CityMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StateCountryID = new SelectList(db.M_StateCountryMaster, "StateCountryID", "StateCode", m_CityMaster.StateCountryID);
            return View(m_CityMaster);
        }

        // GET: M_CityMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_CityMaster m_CityMaster = await db.M_CityMaster.FindAsync(id);
            if (m_CityMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateCountryID = new SelectList(db.M_StateCountryMaster, "StateCountryID", "StateCode", m_CityMaster.StateCountryID);
            return View(m_CityMaster);
        }

        // POST: M_CityMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CityID,CityCode,CityName,StateCountryID,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_CityMaster m_CityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_CityMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StateCountryID = new SelectList(db.M_StateCountryMaster, "StateCountryID", "StateCode", m_CityMaster.StateCountryID);
            return View(m_CityMaster);
        }

        // GET: M_CityMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_CityMaster m_CityMaster = await db.M_CityMaster.FindAsync(id);
            if (m_CityMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_CityMaster);
        }

        // POST: M_CityMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_CityMaster m_CityMaster = await db.M_CityMaster.FindAsync(id);
            db.M_CityMaster.Remove(m_CityMaster);
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
