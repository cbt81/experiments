using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceVisitService.Database;
using ResourceVisitService.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ResourceVisitService {
    [Route("/")]
    [ApiController]
    public class Controller : ControllerBase {
        // GET /
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> Get() {
            using (var ctx = new Context()) {
                var visits = ctx.Visits.ToListAsync();
                return await visits;
            }
        }

        // GET /5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> Get(int id) {
            using (var ctx = new Context()) {
                var visit = await ctx.Visits.FindAsync(id);

                if (visit == null) {
                    return NotFound();
                }

                return visit;
            }
        }

        // POST /
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Visit value) {
            using (var ctx = new Context()) {
                await ctx.Visits.AddAsync(value);

                await ctx.SaveChangesAsync();

                return new JsonResult(
                    new { Result = "Added", Object = value },
                    new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
        }

        // DELETE /5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            using (var ctx = new Context()) {
                var visit = await ctx.Visits.FindAsync(id);

                if (visit == null) {
                    return NotFound();
                }

                ctx.Visits.Remove(visit);

                await ctx.SaveChangesAsync();

                return new JsonResult(
                    new { Result = "Deleted", Id = id },
                    new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
        }
    }
}
