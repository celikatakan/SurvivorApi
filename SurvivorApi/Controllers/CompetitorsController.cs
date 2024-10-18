using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurvivorApi.Data;
using SurvivorApi.Entities;

namespace SurvivorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorsController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var competitors = _context.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitors == null)
                return NotFound();

            return Ok(competitors);
        }
        [HttpGet("categories/{CategoryId:int}")]
        public IActionResult CategoryId(int categoryId)
        {
            var category = _context.Competitors.Where(x=>x.CategoryId == categoryId).ToList();
            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CompetitorEntity competitor)
        {
            _context.Competitors.Add(competitor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new {id = competitor.Id}, competitor);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CompetitorEntity competitor)
        {
            if (id != competitor.Id)
                return BadRequest();

            var request = _context.Competitors.FirstOrDefault(x=> x.Id == id);

            if (request == null)    
                return NotFound();

            request.FirstName = competitor.FirstName;
            request.LastName = competitor.LastName;
            request.CategoryId = competitor.CategoryId;
            _context.SaveChanges();
            return Ok(request);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _context.Competitors.FirstOrDefault(x=>x.Id == id);
            if(competitor == null)
                return NotFound();

            competitor.IsDeleted = true;

            return Ok(competitor);
        }
    }
}
