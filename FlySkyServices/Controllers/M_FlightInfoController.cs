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
    public class M_FlightInfoController : Controller
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: M_FlightInfo
        public async Task<ActionResult> Index()
        {
            var m_FlightInfo = db.M_FlightInfo.Include(m => m.M_AviationCompanyMaster).Include(m => m.M_MasterTable);
            return View(await m_FlightInfo.ToListAsync());
        }

        // GET: M_FlightInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_FlightInfo m_FlightInfo = await db.M_FlightInfo.FindAsync(id);
            if (m_FlightInfo == null)
            {
                return HttpNotFound();
            }
            return View(m_FlightInfo);
        }

        // GET: M_FlightInfo/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.M_AviationCompanyMaster, "CompanyID", "CompanyCode");
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text");
            return View();
        }

        // POST: M_FlightInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FlightId,FlightNumber,RegistrationNo,FlightStatus,IsEconomy,IsPremiumEconomy,IsBusiness,NoOfSeat,CompanyID,Desc,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_FlightInfo m_FlightInfo)
        {
            if (ModelState.IsValid)
            {
                db.M_FlightInfo.Add(m_FlightInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.M_AviationCompanyMaster, "CompanyID", "CompanyCode", m_FlightInfo.CompanyID);
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text", m_FlightInfo.FlightStatus);
            return View(m_FlightInfo);
        }

        // GET: M_FlightInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_FlightInfo m_FlightInfo = await db.M_FlightInfo.FindAsync(id);
            if (m_FlightInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.M_AviationCompanyMaster, "CompanyID", "CompanyCode", m_FlightInfo.CompanyID);
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text", m_FlightInfo.FlightStatus);
            return View(m_FlightInfo);
        }

        // POST: M_FlightInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FlightId,FlightNumber,RegistrationNo,FlightStatus,IsEconomy,IsPremiumEconomy,IsBusiness,NoOfSeat,CompanyID,Desc,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_FlightInfo m_FlightInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_FlightInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.M_AviationCompanyMaster, "CompanyID", "CompanyCode", m_FlightInfo.CompanyID);
            ViewBag.FlightStatus = new SelectList(db.M_MasterTable, "Id", "Text", m_FlightInfo.FlightStatus);
            return View(m_FlightInfo);
        }

        // GET: M_FlightInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_FlightInfo m_FlightInfo = await db.M_FlightInfo.FindAsync(id);
            if (m_FlightInfo == null)
            {
                return HttpNotFound();
            }
            return View(m_FlightInfo);
        }

        // POST: M_FlightInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_FlightInfo m_FlightInfo = await db.M_FlightInfo.FindAsync(id);
            db.M_FlightInfo.Remove(m_FlightInfo);
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
