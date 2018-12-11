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
    public class T_FlightsTableController : Controller
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: T_FlightsTable
        public async Task<ActionResult> Index()
        {
            var t_FlightsTable = db.T_FlightsTable.Include(t => t.M_CityMaster).Include(t => t.M_CityMaster1).Include(t => t.M_FlightInfo).Include(t => t.M_MasterTable).Include(t => t.M_MasterTable1);
            return View(await t_FlightsTable.ToListAsync());
        }

        // GET: T_FlightsTable/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_FlightsTable t_FlightsTable = await db.T_FlightsTable.FindAsync(id);
            if (t_FlightsTable == null)
            {
                return HttpNotFound();
            }
            return View(t_FlightsTable);
        }

        // GET: T_FlightsTable/Create
        public ActionResult Create()
        {
            ViewBag.Departure = new SelectList(db.M_CityMaster, "CityID", "CityCode");
            ViewBag.Arrival = new SelectList(db.M_CityMaster, "CityID", "CityCode");
            ViewBag.FlightId = new SelectList(db.M_FlightInfo, "FlightId", "FlightNumber");
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text");
            ViewBag.DelayStatus = new SelectList(db.M_MasterTable, "Id", "Text");
            return View();
        }

        // POST: T_FlightsTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FlightTableID,FlightId,FlightNumber,FromTime,ToTime,Departure,Arrival,FlightStatus,DelayStatus,DelayedReason,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active,FlightDate")] T_FlightsTable t_FlightsTable)
        {
            if (ModelState.IsValid)
            {
                db.T_FlightsTable.Add(t_FlightsTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Departure = new SelectList(db.M_CityMaster, "CityID", "CityCode", t_FlightsTable.Departure);
            ViewBag.Arrival = new SelectList(db.M_CityMaster, "CityID", "CityCode", t_FlightsTable.Arrival);
            ViewBag.FlightId = new SelectList(db.M_FlightInfo, "FlightId", "FlightNumber", t_FlightsTable.FlightId);
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text", t_FlightsTable.FlightStatus);
            ViewBag.DelayStatus = new SelectList(db.M_MasterTable, "Id", "Text", t_FlightsTable.DelayStatus);
            return View(t_FlightsTable);
        }

        // GET: T_FlightsTable/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_FlightsTable t_FlightsTable = await db.T_FlightsTable.FindAsync(id);
            if (t_FlightsTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departure = new SelectList(db.M_CityMaster, "CityID", "CityCode", t_FlightsTable.Departure);
            ViewBag.Arrival = new SelectList(db.M_CityMaster, "CityID", "CityCode", t_FlightsTable.Arrival);
            ViewBag.FlightId = new SelectList(db.M_FlightInfo, "FlightId", "FlightNumber", t_FlightsTable.FlightId);
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text", t_FlightsTable.FlightStatus);
            ViewBag.DelayStatus = new SelectList(db.M_MasterTable, "Id", "Text", t_FlightsTable.DelayStatus);
            return View(t_FlightsTable);
        }

        // POST: T_FlightsTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FlightTableID,FlightId,FlightNumber,FromTime,ToTime,Departure,Arrival,FlightStatus,DelayStatus,DelayedReason,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active,FlightDate")] T_FlightsTable t_FlightsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_FlightsTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Departure = new SelectList(db.M_CityMaster, "CityID", "CityCode", t_FlightsTable.Departure);
            ViewBag.Arrival = new SelectList(db.M_CityMaster, "CityID", "CityCode", t_FlightsTable.Arrival);
            ViewBag.FlightId = new SelectList(db.M_FlightInfo, "FlightId", "FlightNumber", t_FlightsTable.FlightId);
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text", t_FlightsTable.FlightStatus);
            ViewBag.DelayStatus = new SelectList(db.M_MasterTable, "Id", "Text", t_FlightsTable.DelayStatus);
            return View(t_FlightsTable);
        }

        // GET: T_FlightsTable/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_FlightsTable t_FlightsTable = await db.T_FlightsTable.FindAsync(id);
            if (t_FlightsTable == null)
            {
                return HttpNotFound();
            }
            return View(t_FlightsTable);
        }

        // POST: T_FlightsTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_FlightsTable t_FlightsTable = await db.T_FlightsTable.FindAsync(id);
            db.T_FlightsTable.Remove(t_FlightsTable);
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
