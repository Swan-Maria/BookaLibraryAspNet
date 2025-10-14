using BooksLibraryAspNet.Domain.Models;
using LibraryComplexServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryCardsController : ControllerBase
    {
        private readonly IService<LibraryCard> _service;

        public LibraryCardsController(IService<LibraryCard> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LibraryCard entity)
        {
            var created = await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LibraryCard entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}