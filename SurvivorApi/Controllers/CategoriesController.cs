using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurvivorApi.Data;
using SurvivorApi.Entities;

namespace SurvivorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoriesController(SurvivorDbContext context)
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
            var categories = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (categories == null)
                return NotFound();

            return Ok(categories);

        }
        [HttpPost]
        public IActionResult Create([FromBody] CategoryEntity category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryEntity category)
        {
            if (id != category.Id)
                return BadRequest();

            var request = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (request == null)
                return NotFound();

            request.Name = category.Name;
            request.ModifiedDate = category.ModifiedDate;
            _context.SaveChanges();
            return Ok(request);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
                return NotFound();

            category.IsDeleted = true;

            return Ok(category);
        }
    }
}