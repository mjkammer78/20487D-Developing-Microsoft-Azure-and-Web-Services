using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlueYonder.Flights.Models;

namespace BlueYonder.Flights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly FlightsContext _context;

        public FlightsController(FlightsContext context)
        {
            _context = context;
        }

        // GET api/flights
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return _context.Flights.ToList();
        }

        // GET api/flights/5
        [HttpGet("{id}")]
        public //async
        IActionResult Get(int id)
        {
            //var res = await _context.Flights.FindAsync(id);
            var res = _context.Flights.Find(id);

            if (res == null)
            {
                return NotFound();
            }
            
            //return res;
            return Ok(res);
        }

        // POST api/flights
        [HttpPost]
        public IActionResult Post([FromBody] Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), flight.Id);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            /*Flight res = _context.Flights.Find(id);

            if (res == null)
            {
                return NotFound();
            }

            res.FlightNumber = value;

            return Ok(_context.Update(res));*/
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
