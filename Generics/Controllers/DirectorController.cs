using Generics.Data;
using Generics.Models;
using Generics.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IRepository<Director> _repository;
        private readonly AppDb _appDb;

        public DirectorController(IRepository<Director> repository, AppDb appDb)
        {
            _repository = repository;
            _appDb = appDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var directors = await _repository.GetAllAsync();
            return Ok(directors);
        }
        [HttpGet("{id}",Name ="GetAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var director = await _repository.GetAsync(id);
            return Ok(director);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Director director)
        {
            await _repository.CreateAsync(director);
            return CreatedAtRoute("GetAsync", new { id = director.Id }, director);

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] Director director, int id)
        {
            var dbDirecor = await _appDb.Directors.FindAsync(id);
            if (dbDirecor == null)
                return NotFound("Not found");
            if (director.Id != dbDirecor.Id)
                return BadRequest("Bad Request");
            dbDirecor.Id = director.Id;
            dbDirecor.Name = director.Name;
            await _repository.UpdateAsync(dbDirecor);

            return CreatedAtRoute("GetAsync", new { id = director.Id }, director);
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
