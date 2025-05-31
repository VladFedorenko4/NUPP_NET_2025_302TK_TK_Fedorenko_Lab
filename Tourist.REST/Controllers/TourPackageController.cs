using Microsoft.AspNetCore.Mvc;
using Tourist.Common.Services;
using Tourist.REST.Models;
using TourPackageModel = Tourist.Infrastructure.Models.TourPackageModel;

namespace Tourist.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourPackageController : ControllerBase
    {
        private readonly ICrudService<TourPackageModel> _service;

        public TourPackageController(ICrudService<TourPackageModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourPackageModel>>> GetAll()
        {
            var items = await _service.ReadAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourPackageModel>> Get(Guid id)
        {
            var item = await _service.ReadAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTourPackageModel model)
        {
            var entity = new TourPackageModel
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Genre = model.Genre,
                Year = model.Year,
                Rating = model.Rating
            };

            var created = await _service.CreateAsync(entity);

            if (!created)
                return BadRequest();

            await _service.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] TourPackageModel model)
        {
            if (id != model.Id)
                return BadRequest();

            var updated = await _service.UpdateAsync(model);
            if (!updated)
                return NotFound();
            await _service.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var entity = await _service.ReadAsync(id);
            if (entity == null)
                return NotFound();

            var removed = await _service.RemoveAsync(entity);
            if (!removed)
                return BadRequest();
            await _service.SaveAsync();
            return NoContent();
        }
    }
}
