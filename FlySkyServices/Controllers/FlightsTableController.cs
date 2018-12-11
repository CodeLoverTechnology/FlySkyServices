using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FlySkyServices.Models;

namespace FlySkyServices.Controllers
{
    public class FlightsTableController : ApiController
    {
        private FlightDBEntities db = new FlightDBEntities();

        // GET: api/FlightsTable
        [Route("api/FlightsTable/GetT_FlightsTable")]
        //public IHttpActionResult GetT_FlightsTable(DateTime? FlightDate)
        public IHttpActionResult GetT_FlightsTable()
        {
            DateTime FlightDate = new DateTime();
            IList<RunningFlightInfo> ObjRunningFlightInfoList = new List<RunningFlightInfo>();
            if (FlightDate != null)
            {
                //var RunningFlightInfo = from s in db.T_FlightsTable.Where(x => x.FlightDate == FlightDate) select s;
                var RunningFlightInfo = from s in db.T_FlightsTable select s;
                foreach (var flight in RunningFlightInfo)
                {
                    ObjRunningFlightInfoList.Add(new RunningFlightInfo {
                        FlightId = flight.FlightId,
                        FlightNumber = flight.FlightNumber,
                        FlightDate = flight.FlightDate.ToString(),
                        FromTime = flight.FromTime,
                        ActualFromTime = flight.FromTime,
                        ToTime = flight.ToTime,
                        ActualToTime = flight.ToTime,
                        Arrival = flight.Arrival,
                        ArrivalName = flight.Arrival.ToString(),
                        Departure = flight.Departure,
                        DepartureName = flight.Departure.ToString(),
                        DelayStatus = flight.DelayStatus,
                        DelayStatusName = flight.DelayStatus.ToString(),
                        DelayedReason = flight.DelayedReason,
                        FlightStatus = flight.FlightStatus,
                        FlightStatusName = flight.FlightStatus.ToString(),
                        FlightTableID = flight.FlightTableID,
                        ModifiedDate = flight.ModifiedDate,
                        CreatedDate = flight.CreatedDate,
                        Active = flight.Active
                    });
                }
            }
            return Ok(ObjRunningFlightInfoList);
        }

        // GET: api/FlightsTable/5
        [ResponseType(typeof(T_FlightsTable))]
        public async Task<IHttpActionResult> GetT_FlightsTable(int id)
        {
            T_FlightsTable t_FlightsTable = await db.T_FlightsTable.FindAsync(id);
            if (t_FlightsTable == null)
            {
                return NotFound();
            }

            return Ok(t_FlightsTable);
        }

        // PUT: api/FlightsTable/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutT_FlightsTable(int id, T_FlightsTable t_FlightsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_FlightsTable.FlightTableID)
            {
                return BadRequest();
            }

            db.Entry(t_FlightsTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_FlightsTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FlightsTable
        [HttpPost]
        [Route("api/FlightsTable/PostT_FlightsTable")]
        [ResponseType(typeof(T_FlightsTable))]
        public async Task<IHttpActionResult> PostT_FlightsTable(T_FlightsTable t_FlightsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_FlightsTable.Add(t_FlightsTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = t_FlightsTable.FlightTableID }, t_FlightsTable);
        }

        // DELETE: api/FlightsTable/5
        [ResponseType(typeof(T_FlightsTable))]
        public async Task<IHttpActionResult> DeleteT_FlightsTable(int id)
        {
            T_FlightsTable t_FlightsTable = await db.T_FlightsTable.FindAsync(id);
            if (t_FlightsTable == null)
            {
                return NotFound();
            }

            db.T_FlightsTable.Remove(t_FlightsTable);
            await db.SaveChangesAsync();

            return Ok(t_FlightsTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_FlightsTableExists(int id)
        {
            return db.T_FlightsTable.Count(e => e.FlightTableID == id) > 0;
        }
    }
}