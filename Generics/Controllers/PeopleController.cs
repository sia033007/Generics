using Generics.Data;
using Generics.Models;
using Generics.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IRepository<People> _repository;
        private readonly AppDb _appDb;

        public PeopleController(IRepository<People> repository, AppDb appDb)
        {
            _repository = repository;
            _appDb = appDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var people = await _repository.GetAllAsync();
            return Ok(people);
        }
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var people = await _repository.GetAsync(id);
            return Ok(people);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] People people)
        {
            await _repository.CreateAsync(people);
            return CreatedAtRoute("Get", new { id = people.Id }, people);

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] People people, int id)
        {
            var dbPeople = await _appDb.Directors.FindAsync(id);
            if (dbPeople == null)
                return NotFound("Not found");
            if (people.Id != dbPeople.Id)
                return BadRequest("Bad Request");
            dbPeople.Id = people.Id;
            dbPeople.Name = people.Name;
            await _repository.UpdateAsync(people);

            return CreatedAtRoute("Get", new { id =people.Id }, people);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
