using GreptileKanbanBoardBackend.Data;
using GreptileKanbanBoardBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GreptileKanbanBoardBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]    
    public class KanbanController : ControllerBase
    {
        private readonly InMemoryKanbanContext _context;

        public KanbanController(InMemoryKanbanContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet("columns")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> GetColumns()
        {
            var columns = await _context.Columns.Include(c => c.Cards).ToListAsync();
            return Ok(columns);
        }
    }
}
