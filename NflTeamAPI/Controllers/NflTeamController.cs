using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NflTeamAPI.Data;

namespace NflTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NflTeamController : ControllerBase
    {
        private readonly DataContext _context;

        public NflTeamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NflTeam>>> GetNflTeams()
        {
            return Ok(await _context.NflTeams.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<NflTeam>>> CreateNflTeam(NflTeam team)
        {
            _context.NflTeams.Add(team);
            await _context.SaveChangesAsync();

            return Ok(await _context.NflTeams.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<NflTeam>>> UpdateNflTeam(NflTeam team)
        {
            var dbTeam = await _context.NflTeams.FindAsync(team.Id);
            if(dbTeam == null)
            {
                return BadRequest("Team not found");
            }

            dbTeam.Name = team.Name;
            dbTeam.City = team.City;
            dbTeam.Stadium = team.Stadium;
            dbTeam.Titles = team.Titles;

            await _context.SaveChangesAsync();

            return Ok(await _context.NflTeams.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<NflTeam>>> DeleteTeam(int id)
        {
            var dbTeam = await _context.NflTeams.FindAsync(id);
            if (dbTeam == null)
            {
                return BadRequest("Team not found");
            }

            _context.NflTeams.Remove(dbTeam);
            await _context.SaveChangesAsync();

            return Ok(await _context.NflTeams.ToListAsync());
        }

    }
}
