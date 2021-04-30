using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using portWebApiCore.DAL;
using portWebApiCore.Model;

namespace portWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger _logger;

       
        public ValuesController(ApplicationDBContext context, ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamicPort>>> GetDynamicPort()
        {
            _logger.LogInformation("Get function was called");
            return await _context.DynamicPort.ToListAsync();
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamicPort>> GetdynamicPort(int id)
        {
            _logger.LogInformation($"Get(id) was called with id:{id}");

           var dynamicPort = await _context.DynamicPort.FindAsync(id);

            if (dynamicPort == null)
            {
                _logger.LogError($"Get(id) was called with id:{id} not such values was found");
                return NotFound();

            }
            _logger.LogInformation($"Get(id) was called with id:{id} and returned {dynamicPort.uniqueCode}, {dynamicPort.httpport}");
            return dynamicPort;
        }
        [HttpGet("uc/{uniqueCode}")]
        public async Task<ActionResult<string>> GetdynamicPort(string uniqueCode)
        {
            var dynamicPorts = await _context.DynamicPort.Where(dp=>dp.uniqueCode==uniqueCode).FirstOrDefaultAsync();

            if (dynamicPorts == null)

            {
                _logger.LogError("Get() with parameter:" + uniqueCode + ", has no uniqueCode in Db.");
                return NotFound();
                
            }
           

            if (Request.IsHttps)
            {
                _logger.LogInformation("Get() with parameter:" + uniqueCode + ", valued found in db and return=>"+ dynamicPorts.httpsport.ToString());
                return dynamicPorts.httpsport.ToString();
            }
            else
            {
                _logger.LogInformation("Get() with parameter:" + uniqueCode + ", valued found in db and return=>" + dynamicPorts.httpport.ToString());

                return dynamicPorts.httpport.ToString();
            }
        }


        // PUT: api/Values/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdynamicPort(int id, dynamicPort dynamicPort)
        {
            if (id != dynamicPort.Id)
            {
                return BadRequest();
            }

            _context.Entry(dynamicPort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dynamicPortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Values
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<dynamicPort>> PostdynamicPort(dynamicPort dynamicPort)
        {
            _logger.LogInformation($"Post request was hit with values with uniquecode:{dynamicPort.uniqueCode} , HttpPorts : {dynamicPort.httpport},HttpsPorts :{dynamicPort.httpsport} and id: {dynamicPort.Id}");
            //_context.DynamicPort.Remove(_context.DynamicPort.Where(dp=>dp.httpport== dynamicPort.httpport).FirstOrDefault());
            //_context.DynamicPort.Remove(_context.DynamicPort.Where(dp => dp.httpsport == dynamicPort.httpsport).FirstOrDefault());

            _context.DynamicPort.Add(dynamicPort);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"added new record with uniquecode:{dynamicPort.uniqueCode} , HttpPorts : {dynamicPort.httpport},HttpsPorts :{dynamicPort.httpsport} and id: {dynamicPort.Id}");

            return CreatedAtAction("GetdynamicPort", new { id = dynamicPort.Id }, dynamicPort);
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamicPort>> DeletedynamicPort(int id)
        {
            var dynamicPort = await _context.DynamicPort.FindAsync(id);
            if (dynamicPort == null)
            {
                return NotFound();
            }

            _context.DynamicPort.Remove(dynamicPort);
            await _context.SaveChangesAsync();

            return dynamicPort;
        }

        private bool dynamicPortExists(int id)
        {
            return _context.DynamicPort.Any(e => e.Id == id);
        }
    }
}
